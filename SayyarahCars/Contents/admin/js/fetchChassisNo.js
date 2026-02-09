$(document).ready(function () {
    const inputSelector = '#' + ChassisClientID.ChassisNo;
    const $input = $(inputSelector);
    const $suggest = $('#suggest');

    let debounceTimer = null;
    let selectedIndex = -1;
    let suggestions = [];
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
                    url: "/WebServices/jquerydata.asmx/allchassis",
                    data: JSON.stringify({ CHID: query }),
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


    $(document).on('click', '#suggest li', function () {
        const selectedValue = $(this).data('value');
        $input.val(selectedValue);
        $suggest.hide();

        if (typeof ChassisClientID !== 'undefined') {           
            if (ChassisClientID.btnReload) {
                const $btn = $('#' + ChassisClientID.btnReload);
                $btn.trigger('click'); 
            }
           
            if (ChassisClientID.AllChassisNo) {
                const $allChassisInput = $('#' + ChassisClientID.AllChassisNo);
                const existingValue = $allChassisInput.val();
                const newValue = `'${selectedValue}',${existingValue}`;
                $allChassisInput.val(newValue);
                $input.val('');
            }
        }
    });


    $(document).on('mouseup', function (e) {
        if (!$suggest.is(e.target) && $suggest.has(e.target).length === 0) {
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
                $input.val(selectedValue);
                $suggest.hide();
            }
            return;
        }

        items.removeClass('active');
        $(items[selectedIndex]).addClass('active');
    }


    function renderSuggestions(data, query) {
        if (data.length < 1) {
            $suggest.hide();
            return;
        }

        let html = '';
        const regex = new RegExp(`(${escapeRegex(query)})`, 'gi');

        data.forEach(item => {
            const highlighted = item.Cno.replace(regex, '<strong>$1</strong>');
            html += `<li class="list-group-item list-group-item-action" data-value="${item.Cno}">${highlighted}</li>`;
        });

        $suggest
            .html(html)
            .show();
    }


    function escapeRegex(text) {
        return text.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    }
});
