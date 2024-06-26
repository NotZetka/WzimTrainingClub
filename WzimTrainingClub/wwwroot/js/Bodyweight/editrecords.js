﻿const { error } = require("jquery");

function getDateString(DateObject) {
    var year = String(DateObject.getFullYear());
    var month = String(DateObject.getMonth() + 1);
    month = month.length === 1 ? "0".concat(month) : month;
    var day = String(DateObject.getDate());
    day = day.length === 1 ? "0".concat(day) : day;

    return year + "-" + month + "-" + day;
}

function updateInputNames() {
    $("table tbody tr").each(function (index, element) {
        $(element).find("input[type=number]").attr("name", "Weights[" + String(index) + "]");
        $(element).find("input[type=date]").attr("name", "Dates[" + String(index) + "]");
    });
}

function removeTemplateRow() {
    $("#NewRowTemplate").remove();
}

function removeRow(sender) {
    $(sender).parents("tr").remove();
}

function addNewRow(weight, date) {
    var rowClone = $("#NewRowTemplate").clone();
    rowClone.attr("id", null).removeClass("d-none");
    rowClone.find("input").eq(0).val(weight);
    rowClone.find("input").eq(1).val(date);

    $(".old-dates").prepend(rowClone);
}

function validateNewDate() {
    var newDate = $("#NewDateInput").val();
    var result = true;

    $(".old-date").each(function (index, element) {
        var value = $(element).val();
        if ($(value) == newDate) {
            $("#NewDateInput").addClass("border-danger");
            result = false;
            return false;
        }
    });

    if (result === true)
        $("#NewDateInput").removeClass("border-danger");
    return result;
}

function validateAllDates() {
    var result = true;
    var elements = $(".old-date");
    elements.removeClass("border-danger");
    elements.each(function (outerIndex, outerElement) {
        elements.each(function (innerIndex, innerElement) {
            if (outerIndex === innerIndex)
                return true;
            else {
                if ($(outerElement).val() === $(innerElement).val()) {
                    $(outerElement).addClass("border-danger");
                    $(innerElement).addClass("border-danger");
                    result = false;
                    return true;
                }
            }
        });
    });

    return result;
}


////////  Event Handlers  ////////
function formSubmit_Clicked() {
    if (validateAllDates() === false)
        return;
    removeTemplateRow();
    updateInputNames();
}

function weightFormSubmit() {
    $("#NewWeightInput").val("0");

    $("#NewDateInput").val("1999-01-01");
}

function addRowButton_Clicked() {
    var weightInput = $("#NewWeightInput");
    var dateInput = $("#NewDateInput");

    weightInput.removeClass("border-danger");
    dateInput.removeClass("border-danger");

    if (validateNewDate() === false)
        return;

    var weight = weightInput.val();
    if (weight == "") {
        weightInput.addClass("border-danger");
        return;
    }

    var date = dateInput.val();
    if (date == "") {
        console.log(date);
        dateInput.addClass("border-danger");
        return;
    }

    addNewRow(weight, date);
    weightInput.val("");
}

$(document).ready(function () {
    validateNewDate();
});