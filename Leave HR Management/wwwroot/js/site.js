// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//HR = 1,
//    IT = 2,
//    Creative = 3,
//    Marketing = 4,
//    Sales = 5

function GetDepartmentName(id) {
    if (id == 1) {
        return "HR";
    } 

    if (id == 2) {
        return "IT";
    } 

    if (id == 3) {
        return "Creative";
    } 

    if (id == 4) {
        return "Marketing";
    } 

    if (id == 5) {
        return "Sales";
    } 

    return "Not Defined";
}