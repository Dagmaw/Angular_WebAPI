(function () {
    "use strict";
    angular
        .module("myApp")
        .controller("PersonListCtrl",
            ["personResource",
                PersonListCtrl]);

    function PersonListCtrl(personResource) {
        var vm = this;

        personResource.query(function (data) {
            vm.persons = data;
        });
    }
}());
