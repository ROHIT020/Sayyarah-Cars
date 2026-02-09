// Initialize Flatpickr
const calendar = flatpickr(dateInput, {
    // 📅 Date & Time formats
    dateFormat: "d/m/Y",     // display format
    altInput: true,          // show an alternate input
    altFormat: "l, j F Y",   // human-readable alt format
    allowInput: true,        // let user type date manually

    // ⏳ Date Limits
    minDate: "today",        // block all past dates
    maxDate: "31/12/2025",   // restrict to a max date
    defaultDate: "15/09/2025", // preselected date

    // ❌ Disable specific dates / ranges / rules
    disable: [
        "20/09/2025",  // single date
        { from: "25/09/2025", to: "30/09/2025" }, // range
        function(date) {
            // Example: disable all Sundays
            return (date.getDay() === 0);
        }
    ],

    // ✅ Enable specific dates only (everything else disabled)
    enable: [
        "10/09/2025", "15/09/2025",
        { from: "01/10/2025", to: "05/10/2025" }
    ],

    // 📌 Selection Modes
    mode: "single",   // "single", "multiple", "range"
    inline: false,    // true = always open calendar
    clickOpens: true, // open only on click/focus

    // ⏰ Time Picker
    enableTime: false, // true to allow time picking
    noCalendar: false, // true = only time picker
    time_24hr: true,   // 24hr format instead of AM/PM
    minTime: "09:00",  // earliest time selectable
    maxTime: "18:00",  // latest time selectable

    // 🎨 Appearance & UX
    weekNumbers: true,    // show week numbers
    shorthandCurrentMonth: true, // short month name
    disableMobile: true,  // always show custom UI
    position: "auto center", // position of calendar

    // 🔔 Events (callbacks)
    onOpen: function(selectedDates, dateStr, instance) {
        console.log("Calendar opened:", dateStr);
    },
    onClose: function(selectedDates, dateStr, instance) {
        console.log("Calendar closed:", dateStr);
    },
    onChange: function(selectedDates, dateStr, instance) {
        console.log("Date changed:", dateStr);
    },
    onReady: function(selectedDates, dateStr, instance) {
        console.log("Calendar ready!");
    }
});

// Open calendar on icon click
icon.addEventListener("click", function () {
    calendar.open();
});


<%-- Options for type of calender 
"DateOnly": FPDateFormat="d/m/Y"
"DateTimePicker": FPEnableTime="true"FPDateFormat="d/m/Y H:i"
"TimeOnlyPicker" : FPEnableTime="true" FPNoCalendar="true" FPDateFormat="H:i"   
--%>