angular.module('qly_nhan_vien_luong')
    .controller('LichSuChucVuController', ['$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {
        $scope.showContent = false;
        $scope.showLoading = true;
        $scope.showMessage = false;
        $rootScope.chucVuTable = [];
        baseURL = "http://localhost:65356/";
        console.log(baseURL);

        $rootScope.getLichSuChucVu = function () {
            $http.get(baseURL + 'LichSuChucVu/getLichSuChucVu', { params: { nhan_vien_id: $rootScope.nhan_vien_id } })
            .then(function (response) {
                if (response.data) {
                    $scope.chucVuTable = response.data;
                    length = $scope.chucVuTable.length;
                    for (i = 0; i < length; i++) {
                        if ($scope.chucVuTable[i].ngay_bat_dau && !($scope.chucVuTable[i].ngay_bat_dau instanceof Date)) {
                            $scope.chucVuTable[i].ngay_bat_dau = new Date(parseInt($scope.chucVuTable[i].ngay_bat_dau.substr(6)));
                        }
                        if ($scope.chucVuTable[i].ngay_ket_thuc && !($scope.chucVuTable[i].ngay_ket_thuc instanceof Date)) {
                            $scope.chucVuTable[i].ngay_ket_thuc = new Date(parseInt($scope.chucVuTable[i].ngay_ket_thuc.substr(6)));
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