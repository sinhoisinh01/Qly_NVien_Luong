angular.module('qly_nhan_vien_luong', ['ngAnimate', 'ngSanitize', 'ui.bootstrap'])
    .constant("baseURL", "http://localhost:65356/")
    .filter("myfilter", function () {
        return function (items, from, to) {
            var arrayToReturn = [];
            for (var i = 0; i < items.length; i++) {
                var ngay_bat_dau = items.ngay_bat_dau,
                    ngay_ket_thuc = items.ngay_ket_thuc;
                if (from >= ngay_bat_dau && (ngay_ket_thuc == null || ngay_ket_thuc <= to)) {
                    arrayToReturn.push(items[i]);
                }
            }

            return arrayToReturn;
        };
    });