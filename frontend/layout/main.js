function openModal() {
  var modal = document.getElementById("reg-modal");
  modal.style.display = "block";
}

function closeMoadl() {
  var modal = document.getElementById("reg-modal");
  modal.style.display = "none";
}

window.onclick = function (event) {
  var modal = document.getElementById("reg-modal");
  if (event.target == modal) {
    modal.style.display = "none";
  }
};
