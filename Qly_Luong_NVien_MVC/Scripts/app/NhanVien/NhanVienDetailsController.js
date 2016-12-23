angular.module('qly_nhan_vien_luong')
    .controller('NhanVienDetailsController', ['$rootScope', '$scope', '$http', function ($rootScope, $scope, $http) {
        $scope.showContent = false;
        $scope.showLoading = false;
        $scope.showMessage = false;
        $scope.message = 'Không tồn tại dữ liệu!';

        $scope.ngachTable = [];
        $scope.chucVuTable = [];

        baseURL = "http://localhost:65356/";

        $scope.tinhLuong = function () {
            $scope.showLoading = true;
            $http.get(baseURL + 'NhanVien/getLichSu', { params: { nhan_vien_id: $scope.nhan_vien_id } })
        .then(function (response) {
                if (response.data) {
                    $scope.ngachTable = response.data.lich_su_ngach;
                    $scope.chucVuTable = response.data.lich_su_chuc_vu;
                    $scope.luong_co_ban = response.data.luong_co_ban.gia_tri;

                    length = $scope.ngachTable.length;
                    for (var i = 0; i < length; i++) {
                        if ($scope.ngachTable[i].ngay_bat_dau && !($scope.ngachTable[i].ngay_bat_dau instanceof Date)) {
                            $scope.ngachTable[i].ngay_bat_dau = new Date(parseInt($scope.ngachTable[i].ngay_bat_dau.substr(6)));
                        }
                        if ($scope.ngachTable[i].ngay_ket_thuc && !($scope.ngachTable[i].ngay_ket_thuc instanceof Date)) {
                            $scope.ngachTable[i].ngay_ket_thuc = new Date(parseInt($scope.ngachTable[i].ngay_ket_thuc.substr(6)));
                        }
                    }

                    length = $scope.chucVuTable.length;
                    for (var i = 0; i < length; i++) {
                        if ($scope.chucVuTable[i].ngay_bat_dau && !($scope.chucVuTable[i].ngay_bat_dau instanceof Date)) {
                            $scope.chucVuTable[i].ngay_bat_dau = new Date(parseInt($scope.chucVuTable[i].ngay_bat_dau.substr(6)));
                        }
                        if ($scope.chucVuTable[i].ngay_ket_thuc && !($scope.chucVuTable[i].ngay_ket_thuc instanceof Date)) {
                            $scope.chucVuTable[i].ngay_ket_thuc = new Date(parseInt($scope.chucVuTable[i].ngay_ket_thuc.substr(6)));
                        }
                    }

                    $scope.salaryObj = calculateSalary($scope.ngachTable, $scope.chucVuTable, $scope.luong_co_ban, $scope.dt);

                    console.log($scope.salaryObj);
                    
                    if ($scope.salaryObj.salaryTable.length == 0) {
                        $scope.showContent = false;
                        $scope.showMessage = true;
                    }
                    else {
                        $scope.showContent = true;
                        $scope.showMessage = false;
                    }
                }
                else {
                    $scope.showContent = false;
                    $scope.showMessage = true;
                }
                
                $scope.showLoading = false;
            });
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
    }]);