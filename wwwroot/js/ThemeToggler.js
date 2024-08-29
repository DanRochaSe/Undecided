document.addEventListener('DOMContentLoaded', function () {
    var theme = localStorage.getItem('theme') || 'light';
    SetTheme();
})


function SetTheme(theme) {
    document.body.setAttribute('data-bs-theme', theme);
}


