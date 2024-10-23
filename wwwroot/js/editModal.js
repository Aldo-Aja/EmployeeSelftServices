var editModal = document.getElementById("editModal");
var editClose = document.getElementsByClassName("close")[1];

function openEditModal(id, name, value) {
    document.getElementById("editBankId").value = id;

    document.getElementById("editName").value = name;
    document.getElementById("editValue").value = value;

    editModal.style.display = "block";
}
editClose.onclick = function () {
    editModal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == editModal) {
        editModal.style.display = "none";
    }
}
