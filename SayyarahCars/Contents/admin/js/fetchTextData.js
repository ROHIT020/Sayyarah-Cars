$(document).ready(function () {
    $(".auto-search").each(function () {
        const $input = $(this);
        const proc = $input.data('proc');
        let debounceTimer = null;
        let selectedIndex = -1;
        let suggestions = [];
      
        let $suggest = $input.siblings('ul.SearchSuggest');
        if ($suggest.length === 0) {
            $suggest = $('<ul class="list-group mt-1 shadow-sm SearchSuggest" style="display: none;"></ul>');
            $input.after($suggest);
        }

        $input.on('keyup', function (e) {
            const key = e.which || e.keyCode;

            if (key === 38 || key === 40 || key === 13) {
                handleNavigation(key);
                return;
            }

            const query = $input.val();
            selectedIndex = -1;
            clearTimeout(debounceTimer);

            if (query.length > 2) {
                debounceTimer = setTimeout(() => {
                    $.ajax({
                        type: "POST",
                        url: "/WebServices/jquerydata.asmx/GenericSearchMethod",
                        data: JSON.stringify({ searchText: query, procedureName: proc }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            suggestions = JSON.parse(response.d);
                            renderSuggestions(suggestions, query);
                        },
                        error: function (xhr, status, error) {
                            console.error("AJAX Error:", status, error);
                        }
                    });
                }, 300);
            } else {
                $suggest.hide();
            }
        });

        function handleNavigation(key) {
            const items = $suggest.find('li');
            if (items.length === 0) return;

            if (key === 40) {
                selectedIndex = (selectedIndex + 1) % items.length;
            } else if (key === 38) {
                selectedIndex = (selectedIndex - 1 + items.length) % items.length;
            } else if (key === 13) {
                if (selectedIndex >= 0) {
                    const selectedValue = $(items[selectedIndex]).data('value');
                    $input.val(selectedValue).trigger('change');
                    $suggest.hide();
                }
                return;
            }

            items.removeClass('active');
            $(items[selectedIndex]).addClass('active');
        }

        function renderSuggestions(data, query) {
            if (!data || data.length === 0) {
                $suggest.hide();
                return;
            }

            const regex = new RegExp(`(${escapeRegex(query)})`, 'gi');
            let html = '';

            data.forEach(item => {
                const highlighted = item.searchValue.replace(regex, '<strong>$1</strong>');
                html += `<li class="list-group-item list-group-item-action" data-value="${item.searchValue}">${highlighted}</li>`;
            });

            $suggest.html(html).show();
        }
       
        $suggest.on('click', 'li', function () {
            const selectedValue = $(this).data('value');
            $input.val(selectedValue).trigger('change');
            $suggest.hide();
          
        });
       
        $(document).on('mouseup', function (e) {
            if (!$suggest.is(e.target) && $suggest.has(e.target).length === 0 && !$input.is(e.target)) {
                $suggest.hide();
            }
        });

        function escapeRegex(text) {
            return text.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
        }
    });
});
