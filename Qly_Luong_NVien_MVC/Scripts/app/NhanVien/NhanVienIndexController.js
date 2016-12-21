angular.module('qly_nhan_vien_luong')
    .controller('NhanVienIndexController', ['$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {
        $scope.showContent = false;
        $scope.showLoading = true;
        $scope.showMessage = false;
        $scope.sortKey = 'ten';
        $scope.pagination = { begin: 0, numberOfPage: 1, perPage: 5, pages: [], hideLeft: true, hideRight: false };
        $scope.nhanVienTable = [];

        $http.get('/NhanVien/getListNhanVien')
            .then(function (response) {
                if (response.data) {
                    $scope.nhanVienTable = response.data;
                    length = $scope.nhanVienTable.length;
                    for (i = 0; i < length; i++) {
                        if ($scope.nhanVienTable[i].ngay_sinh && !($scope.nhanVienTable[i].ngay_sinh instanceof Date)) {
                            $scope.nhanVienTable[i].ngay_sinh = new Date(parseInt($scope.nhanVienTable[i].ngay_sinh.substr(6)));
                        }
                        if ($scope.nhanVienTable[i].ngay_vao_lam && !($scope.nhanVienTable[i].ngay_vao_lam instanceof Date)) {
                            $scope.nhanVienTable[i].ngay_vao_lam = new Date(parseInt($scope.nhanVienTable[i].ngay_vao_lam.substr(6)));
                        }
                        if ($scope.nhanVienTable[i].ngay_nghi_lam && !($scope.nhanVienTable[i].ngay_nghi_lam instanceof Date)) {
                            $scope.nhanVienTable[i].ngay_nghi_lam = new Date(parseInt($scope.nhanVienTable[i].ngay_nghi_lam.substr(6)));
                        }
                    }

                    $scope.pagination.numberOfPage = Math.ceil(length / $scope.pagination.perPage);
                    $scope.pagination.showHideArrow();
                    for (i = 1; i <= $scope.pagination.numberOfPage; i++) {
                        $scope.pagination.pages.push(i);
                    }

                    $scope.showContent = true;
                    $scope.showMessage = false;
                }
                else {
                    $scope.showContent = false;
                    $scope.showMessage = true;
                }
                $scope.showLoading = false;
            },
            function (error) {
                $rootScope.hasInternetError = true;
            });

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.pagination.getPage = function (currentPage) {
            $scope.pagination.begin = $scope.pagination.perPage * (currentPage - 1);
            $scope.pagination.showHideArrow();
        }
        $scope.pagination.nextPage = function () {
            if ($scope.pagination.begin < $scope.pagination.numberOfPage)
                $scope.pagination.getPage($scope.pagination.begin + 1);
        }
        $scope.pagination.backPage = function () {
            if ($scope.pagination.begin > 1)
                $scope.pagination.getPage($scope.pagination.begin - 1);
        }
        $scope.pagination.firstPage = function () {
            $scope.pagination.getPage(1);
        }
        $scope.pagination.finalPage = function () {
            $scope.pagination.getPage($scope.pagination.numberOfPage);
        }
        $scope.pagination.showHideArrow = function () {
            if ($scope.pagination.numberOfPage == 1) {
                $scope.pagination.hideLeft = true;
                $scope.pagination.hideRight = true;
                return;
            }
            if ($scope.pagination.begin == 0) {
                $scope.pagination.hideLeft = true;
                $scope.pagination.hideRight = false;
                return;
            }
            if ($scope.pagination.begin == $scope.pagination.perPage * ($scope.pagination.numberOfPage - 1)) {
                $scope.pagination.hideLeft = false;
                $scope.pagination.hideRight = true;
                return;
            }
        }
    }]);