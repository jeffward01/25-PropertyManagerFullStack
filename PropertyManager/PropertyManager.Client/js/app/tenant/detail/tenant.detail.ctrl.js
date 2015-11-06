angular.module('app').controller('TenantDetailController', function ($scope, $stateParams, Tenant, $state) {

    // If an ID was passed to state, then a tenant is being edited: get the tenant to update
    //  otherwise a tenant is being added: create a new tenant
    if ($stateParams.id) {
        $scope.tenant = Tenant.get({
            id: $stateParams.id
        });
    } else {
        $scope.tenant = new Tenant();
    }

    // Save tenant:
    // If an ID was passed to state, then a tenant is being edited: update the tenant
    //  otherwise a tenant is being added: save the tenant
    // After updating or saving, change state to tenants.list
    $scope.saveTenant = function () {


        //Validation to ensure no fields are empty
        if (($('#tenantFirstName').val() === "") || ($('#tenantLastName').val() === "") || ($('#tenantEmailAddress').val() === "") || ($('#tenantTelephone').val() === "")) {
            alert("Please input all fields");
            return false;
        }
        var tel = $('#tenantTelephone').val();

        //Validation for the phonenumber length

        if ((tel.length >= 13) || (tel.length <= 6)) {
            alert("Please enter a valid phone number length.  more than 7  and less than 12");
            return false;
        }



        tel = function (tel) {

            return function (tel) {
                if (!tel) {
                    return '';
                }

                var value = tel.toString().trim().replace(/^\+/, '');

                if (value.match(/[^0-9]/)) {
                    return tel;
                }

                var country, city, number;

                switch (value.length) {
                case 10: // +1PPP####### -> C (PPP) ###-####
                    country = 1;
                    city = value.slice(0, 3);
                    number = value.slice(3);
                    break;

                case 11: // +CPPP####### -> CCC (PP) ###-####
                    country = value[0];
                    city = value.slice(1, 4);
                    number = value.slice(4);
                    break;

                case 12: // +CCCPP####### -> CCC (PP) ###-####
                    country = value.slice(0, 3);
                    city = value.slice(3, 5);
                    number = value.slice(5);
                    break;

                default:
                    return tel;
                }

                if (country == 1) {
                    country = "";
                }

                number = number.slice(0, 3) + '-' + number.slice(3);

                return (country + " (" + city + ") " + number).trim();
            };
        }

        $('#tenantTelephone').val(tel);





        //Success Call back and Change of State
        var successCallback = function () {
            $state.go('app.tenant.grid');
        };

        if ($scope.tenant.TenantId) {
            $scope.tenant.$update(successCallback);
        } else {
            $scope.tenant.$save(successCallback);
        }
        toastr.success('Tenant was added!', 'New Tenant was Saved!');

    };

    var validatePhoneNumber = function (tel) {
        return function (tel) {
            if (!tel) {
                return '';
            }

            var value = tel.toString().trim().replace(/^\+/, '');

            if (value.match(/[^0-9]/)) {
                return tel;
            }

            var country, city, number;

            switch (value.length) {
            case 10: // +1PPP####### -> C (PPP) ###-####
                country = 1;
                city = value.slice(0, 3);
                number = value.slice(3);
                break;

            case 11: // +CPPP####### -> CCC (PP) ###-####
                country = value[0];
                city = value.slice(1, 4);
                number = value.slice(4);
                break;

            case 12: // +CCCPP####### -> CCC (PP) ###-####
                country = value.slice(0, 3);
                city = value.slice(3, 5);
                number = value.slice(5);
                break;

            default:
                return tel;
            }

            if (country == 1) {
                country = "";
            }

            number = number.slice(0, 3) + '-' + number.slice(3);

            return (country + " (" + city + ") " + number).trim();
        };
    }

});