angular.module('qly_nhan_vien_luong')
    .controller('LichSuNgachController', ['$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {
        $scope.showContent = false;
        $scope.showLoading = true;
        $scope.showMessage = false;
        $rootScope.ngachTable = [];
        baseURL = "http://localhost:65356/";
        console.log(baseURL);
        $rootScope.getLichSuNgach = function () {
            $http.get(baseURL + 'LichSuNgach/getLichSuNgach', { params: { nhan_vien_id: $rootScope.nhan_vien_id } })
            .then(function (response) {
                if (response.data) {
                    $scope.ngachTable = response.data;
                    length = $scope.ngachTable.length;
                    for (i = 0; i < length; i++) {
                        if ($scope.ngachTable[i].ngay_bat_dau && !($scope.ngachTable[i].ngay_bat_dau instanceof Date)) {
                            $scope.ngachTable[i].ngay_bat_dau = new Date(parseInt($scope.ngachTable[i].ngay_bat_dau.substr(6)));
                        }
                        if ($scope.ngachTable[i].ngay_ket_thuc && !($scope.ngachTable[i].ngay_ket_thuc instanceof Date)) {
                            $scope.ngachTable[i].ngay_ket_thuc = new Date(parseInt($scope.ngachTable[i].ngay_ket_thuc.substr(6)));
                        }
                    }

                    /*$scope.pagination.numberOfPage = Math.ceil(length / $scope.pagination.perPage);
                    $scope.pagination.showHideArrow();
                    for (i = 1; i <= $scope.pagination.numberOfPage; i++) {
                        $scope.pagination.pages.push(i);
                    }*/

                    $scope.showContent = true;
                    $scope.showMessage = false;
                }
                else {
                    $scope.showContent = false;
                    $scope.showMessage = true;
                }
                $scope.showLoading = false;
            });
        };
    }]);