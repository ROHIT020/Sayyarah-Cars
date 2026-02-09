<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateSelector.ascx.cs" Inherits="SayyarahCars.Contents.DateSelector" %>


<style>
    .clear-date {
    position: absolute;
    right: 40px; /* space before calendar icon */
    top: 50%;
    transform: translateY(-50%);
    cursor: pointer;
    font-size: 18px;
    color: rgb(219, 22, 22);
    z-index: 10;
    display: none; /* hidden until value is set */
    padding: 5px 8px;
    background-color: #f1f4f7;
    border: 1px solid #e5e5e5;
    border-radius: 4px;
    margin-right:5px;
    transition: all 0.2s ease-in-out;
}

    .clear-date:hover {
        background-color: rgb(219, 22, 22);
        color: #fff;
        border-color: rgb(200, 20, 20);
    }

</style>
<div class="input-group" runat="server" id="btgp" style="position: relative;">
    <asp:TextBox 
        ID="txt_Date" 
        runat="server" 
        CssClass="form-control pr-5" 
        placeholder="DD/MM/YYYY" 
        autocomplete="off" 
        MaxLength="16" />
    <span id="clickme" runat="server" class="input-group-text" style="cursor: pointer;">
        <i class="ti ti-calendar-event"></i>
    </span>
</div>


<script type="text/javascript">
    document.addEventListener("DOMContentLoaded", function () {
        const dateInput = document.getElementById("<%= txt_Date.ClientID %>");
      const icon = document.getElementById("<%= clickme.ClientID %>");
      const optionsField = document.getElementById("<%= hiddenOptions.ClientID %>");
      const options = JSON.parse(optionsField?.value || "{}");

      const calendar = flatpickr(dateInput, {
          ...options,
          allowInput: true
      });

      // Create clear icon with CSS class
      const clearIcon = document.createElement("span");
      clearIcon.innerHTML = "&times;";
      clearIcon.classList.add("clear-date");

      // Add to wrapper
      dateInput.parentNode.appendChild(clearIcon);

      // Show/hide clear icon
      function toggleClearIcon() {
          clearIcon.style.display = dateInput.value ? "block" : "none";
      }

      dateInput.addEventListener("input", toggleClearIcon);
      calendar.config.onChange.push(toggleClearIcon);
      calendar.config.onClose.push(toggleClearIcon);

      // Clear click action
      clearIcon.addEventListener("click", function () {
          calendar.clear();
          dateInput.value = "";
          dateInput.removeAttribute("value");
          toggleClearIcon();
      });

      // Open calendar on calendar icon click
      icon.addEventListener("click", function () {
          calendar.open();
      });

      // Initial state
      toggleClearIcon();
  });

</script>

<asp:HiddenField ID="hiddenOptions" runat="server" />
