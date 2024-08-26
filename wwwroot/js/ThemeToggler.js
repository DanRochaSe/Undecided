document.addEventListener('DOMContentLoaded', function () {
    debugger;
    var theme = localStorage.getItem('theme') || 'light';
    SetTheme();
})


function SetTheme(theme) {
    debugger;
    document.body.setAttribute('data-bs-theme', theme);
}