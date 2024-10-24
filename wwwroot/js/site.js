// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Check if dark mode is already enabled from previous session
if (localStorage.getItem('theme') === 'dark') {
    document.body.classList.add('dark-mode');
}

// Toggle dark mode
const toggleButton = document.getElementById('darkModeToggle');
toggleButton.addEventListener('click', function (event) {
    event.preventDefault();
    document.body.classList.toggle('dark-mode');

    // Save the theme preference in localStorage
    if (document.body.classList.contains('dark-mode')) {
        localStorage.setItem('theme', 'dark');
    } else {
        localStorage.removeItem('theme');
    }
});
