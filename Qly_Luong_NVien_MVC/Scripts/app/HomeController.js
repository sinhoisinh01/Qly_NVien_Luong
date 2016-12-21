angular.module('qly_nhan_vien_luong')
    .controller('HomeController', ['$rootScope', '$scope', '$http', '$uibModal', function ($rootScope, $scope, $http, $uibModal) {
        $scope.showNhanVien = false;
        $scope.showLoading = false;
        $scope.showMessage = false;
        $scope.luong = 0;
        $scope.salaryTable = [];

        $scope.toDate = new Date();
        $scope.fromDate = new Date($scope.toDate.getFullYear(), 0, 1);

        $scope.getNhanVien = function () {
            $scope.showLoading = true;
            $http.get('/NhanVien/getNhanVienByMaSo', { params: { uid: $scope.ma_so } })
                .then(function (response) {
                    if (response.data) {
                        $scope.nhan_vien = response.data;
                        $scope.nhan_vien.ngay_sinh = new Date(parseInt($scope.nhan_vien.ngay_sinh.substr(6)));
                        $http.get('/TinhLuong/getLuongCoBan')
                            .then(function (response) {
                                $scope.luong_co_ban = response.data.gia_tri;
                            });
                        $http.get('/TinhLuong/get', { params: { id: $scope.nhan_vien.id } })
                            .then(function (response) {
                                $scope.salaryTable = response.data;

                                var length = $scope.salaryTable.length;
                                for (var i = 0; i < length; i++)
                                {
                                    if ($scope.salaryTable[i].ngay_bat_dau && !($scope.salaryTable[i].ngay_bat_dau instanceof Date))
                                        $scope.salaryTable[i].ngay_bat_dau = new Date(parseInt($scope.salaryTable[i].ngay_bat_dau.substr(6)));
                                    if ($scope.salaryTable[i].ngay_ket_thuc && !($scope.salaryTable[i].ngay_ket_thuc instanceof Date))
                                        $scope.salaryTable[i].ngay_ket_thuc = new Date(parseInt($scope.salaryTable[i].ngay_ket_thuc.substr(6)));
                                }

                                $scope.tinhLuong();
                                $scope.showNhanVien = true;
                                $scope.showMessage = false;
                            });
                    }
                    else {
                        $scope.showNhanVien = false;
                        $scope.showMessage = true;
                    }
                    $scope.showLoading = false;
                },
                function (error) {
                    $rootScope.hasInternetError = true;
                });
        };

        $scope.tinhLuong = function () {
            $scope.luong = 0;
            $scope.timeTable = calculateSalary($scope, $scope.dt);
            $scope.luong_thuc_lanh = Math.round($scope.luong * 93 / 100);
        };

        /*
         * Phần date picker
         * Link: https://angular-ui.github.io/bootstrap/
         */
        $scope.dateFormat = "dd/MM/yyyy";

        $scope.today = function () {
            $scope.dt = new Date();
        };
        $scope.today();

        $scope.clear = function () {
            $scope.dt = null;
        };

        $scope.inlineOptions = {
            customClass: getDayClass,
            minDate: new Date(),
            showWeeks: true
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.toggleMin = function () {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
        };

        $scope.toggleMin();

        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };

        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };

        $scope.setDate = function (year, month, day) {
            $scope.dt = new Date(year, month, day);
        };

        $scope.popup1 = {
            opened: false
        };

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        $scope.events = [
          {
              date: tomorrow,
              status: 'full'
          },
          {
              date: afterTomorrow,
              status: 'partially'
          }
        ];

        function getDayClass(data) {
            var date = data.date,
              mode = data.mode;
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        }
    }])
;