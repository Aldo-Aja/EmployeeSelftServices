var modal = document.getElementById("createModal");
var btn = document.getElementById("openCreateModal");
var span = document.getElementsByClassName("close")[0];

btn.onclick = function () {
    modal.style.display = "block";
}
span.onclick = function () {
    modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
document.getElementById("createBankForm").onsubmit = function (event) {
    event.preventDefault();
    this.submit();
}
