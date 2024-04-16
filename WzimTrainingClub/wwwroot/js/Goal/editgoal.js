$(document).ready(function () {
    typeRadio_Changed();
});

function typeRadio_Changed() {
    var weightliftingRadio = document.getElementById("WeightliftingRadio");
    var weightliftingGroup = document.getElementById("WeightliftingGroup");
    var timedGroup = document.getElementById("TimedGroup");

    if (weightliftingRadio.checked) {
        weightliftingGroup.classList.remove("d-none");
        timedGroup.classList.add("d-none");
    } else {
        weightliftingGroup.classList.add("d-none");
        timedGroup.classList.remove("d-none");
    }
}

function validateForm() {
    var timedRadio = document.getElementById("TimedRadio");
    var quantityUnitInput = document.getElementsByName("GoalInput.QuantityUnit")[0];
    if (timedRadio.checked) {
        quantityUnitInput.setAttribute("required", "required");
    } else {
        quantityUnitInput.removeAttribute("required");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    typeRadio_Changed();
});

document.querySelector("form").addEventListener("submit", function (event) {
    validateForm();
});