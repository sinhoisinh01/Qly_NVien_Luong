const BAT_DAU_SAU_THOI_DIEM_XET = 1;
const KET_THUC_TRUOC_THANG_DANG_XET = 2;
const BAT_DAU_TRUOC_THANG_DANG_XET = 3;
const BAT_DAU_TRONG_THANG_DANG_XET = 4;
const KET_THUC_TRUOC_THOI_DIEM_XET = 5;
const KET_THUC_TAI_THOI_DIEM_XET = 6;
const KET_THUC_SAU_THOI_DIEM_XET = 7;

/*
 * Tính số ngày của 1 tháng được lấy từ 1 thời điểm
 * Input: date. Ex: 20/11/2016
 * Output: 30
 */
function getDaysOfDate(dt) {
    switch (dt.getMonth()) {
        case 2:
            if (dt.getFullYear() % 4 == 0)
                return 29;
            else return 28;
            break;
        case 4:
        case 6:
        case 9:
        case 11:
            return 30;
            break;
        default:
            return 31;
            break;
    }
}

/*
 * Tính lương của từng dòng theo công thức
 */
function calculateSalaryByRow(obj, scope) {
    obj.thanh_tien = (obj.chuc_vu.he_so_chuc_vu + obj.he_so_luong.he_so) * scope.luong_co_ban;
    obj.thanh_tien = obj.he_so_luong.vuot_khung == null ? (obj.thanh_tien / getDaysOfDate(scope.dt) * obj.so_ngay) : (obj.thanh_tien * obj.he_so_luong.vuot_khung) / getDaysOfDate(scope.dt) * obj.so_ngay;
}

/*
 * Tính lương từ ngày 1 đến thời điểm xét lương trong tháng
 */
function calculateSalary(scope, date) {
    var numberOfDays = date.getDate();
    var timeTable = [];
    for (var i = 1; i <= numberOfDays; i++) {
        var dt = new Date(date.getFullYear(), date.getMonth(), i);
        var maxRow = getMaxSalaryByExactlyDay(getSalaryByDate(scope, dt));
        timeTable.push(maxRow);
    }   

    var tmp = [];
    tmp.push(timeTable[0]);
    var index = 0;
    var count = 1;
    for (var i = 1; i < numberOfDays; i++) {
        if (timeTable[i].id == tmp[index].id) {
            count++;
        }
        else {
            tmp[index].so_ngay = count;
            tmp.push(timeTable[i]);
            count = 1;
            index++;
        }

        if (i == numberOfDays - 1) {
            tmp[index].so_ngay = count;
        }
    }
    for (var i = 0; i < tmp.length; i++)
    {
        scope.luong += tmp[index].so_ngay * tmp[index].thanh_tien;
    }
    return tmp;
}

/*
 * Tính dòng lớn nhất trong các dòng dữ liệu lương của 1 ngày
 */
function getMaxSalaryByExactlyDay(salaryData) {
    if (salaryData) {
        maxRow = salaryData[0];
        var length = salaryData.length;
        for (var i = 1; i < length; i++) {
            if (salaryData[i].thanh_tien >= maxRow.thanh_tien)
                maxRow = salaryData[i];
        }
        return maxRow;
    }
    return null;
}

/*
 * Tính lương theo 1 khoảng thời gian cho trước
 */
function getSalaryByDate(scope, date) {
    var salaryData = [];
    var length = scope.salaryTable.length;
    for (var i = 0; i < length; i++) {
        if (scope.salaryTable[i].ngay_bat_dau && !(scope.salaryTable[i].ngay_bat_dau instanceof Date))
            scope.salaryTable[i].ngay_bat_dau = new Date(parseInt(scope.salaryTable[i].ngay_bat_dau.substr(6)));
        if (scope.salaryTable[i].ngay_ket_thuc && !(scope.salaryTable[i].ngay_ket_thuc instanceof Date))
            scope.salaryTable[i].ngay_ket_thuc = new Date(parseInt(scope.salaryTable[i].ngay_ket_thuc.substr(6)));

        switch (getTimeTypeOfRow(scope.salaryTable[i], date)) {
            case (BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_SAU_THOI_DIEM_XET):
            case (BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_TAI_THOI_DIEM_XET):
                scope.salaryTable[i].ngay_bat_dau_lam = new Date(date.getFullYear(), date.getMonth(), 1);
                scope.salaryTable[i].so_ngay = 1;
                calculateSalaryByRow(scope.salaryTable[i], scope);
                salaryData.push(scope.salaryTable[i]);
                break;
            case (BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_SAU_THOI_DIEM_XET):
            case (BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_TAI_THOI_DIEM_XET):
                scope.salaryTable[i].so_ngay = 1;
                calculateSalaryByRow(scope.salaryTable[i], scope);
                salaryData.push(scope.salaryTable[i]);
                break;
            case (BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_TRUOC_THOI_DIEM_XET):
                scope.salaryTable[i].ngay_bat_dau_lam = new Date(scope.dt.getFullYear(), scope.dt.getMonth(), 1);
                scope.salaryTable[i].so_ngay = 1;
                calculateSalaryByRow(scope.salaryTable[i], scope);
                salaryData.push(scope.scope.salaryTable[i]);
                break;
            case (BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_TRUOC_THOI_DIEM_XET):
                scope.salaryTable[i].so_ngay = 1;
                calculateSalaryByRow(scope.salaryTable[i], scope);
                salaryData.push(scope.scope.salaryTable[i]);
                break;
            default: break;
        }
    }
    return salaryData;
}

/*
 * Kiểm tra loại dòng
 */
function getTimeTypeOfRow(row, thoi_diem_xet) {
    ngay_bat_dau = row.ngay_bat_dau.getDate();
    thang_bat_dau = row.ngay_bat_dau.getMonth();
    nam_bat_dau = row.ngay_bat_dau.getFullYear();

    if (row.ngay_ket_thuc != null) {
        ngay_ket_thuc = row.ngay_ket_thuc.getDate();
        thang_ket_thuc = row.ngay_ket_thuc.getMonth();
        nam_ket_thuc = row.ngay_ket_thuc.getFullYear();
    }

    ngay_dang_xet = thoi_diem_xet.getDate();
    thang_dang_xet = thoi_diem_xet.getMonth();
    nam_dang_xet = thoi_diem_xet.getFullYear();

    // Bắt đầu sau thời điểm xét
    if (row.ngay_bat_dau > thoi_diem_xet)
        return BAT_DAU_SAU_THOI_DIEM_XET;

    // Kết thúc trước tháng đang xét
    if (row.ngay_ket_thuc != null && nam_ket_thuc < nam_dang_xet)
        return KET_THUC_TRUOC_THANG_DANG_XET;
    else if (row.ngay_ket_thuc != null && nam_ket_thuc == nam_dang_xet && thang_ket_thuc < thang_dang_xet)
        return KET_THUC_TRUOC_THANG_DANG_XET;

    /*--Kết thúc sau thời điểm xét--*/
    // Bắt đầu trước tháng đang xét
    if (thang_bat_dau < thang_dang_xet && (row.ngay_ket_thuc == null || thang_ket_thuc > thang_dang_xet))
        return BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_SAU_THOI_DIEM_XET;
    // Bắt đầu trong tháng đang xét
    if (thang_bat_dau == thang_dang_xet && (row.ngay_ket_thuc == null || thang_ket_thuc > thang_dang_xet))
        return BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_SAU_THOI_DIEM_XET;

    if (row.ngay_ket_thuc != null) {
        /*--Kết thúc trong tháng đang xét nhưng trước thời điểm xét--*/
        // Bắt đầu trước tháng đang xét
        if (thang_bat_dau < thang_dang_xet && thang_ket_thuc < thang_dang_xet)
            return BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_TRUOC_THOI_DIEM_XET;
        // Bắt đầu trong tháng đang xét
        if (thang_bat_dau == thang_dang_xet && thang_ket_thuc < thang_dang_xet)
            return BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_TRUOC_THOI_DIEM_XET;

        /*--Kết thúc ngay tại thời điểm xét--*/
        // Bắt đầu trước tháng đang xét
        if (thang_bat_dau < thang_dang_xet && thang_ket_thuc == thang_dang_xet)
            return BAT_DAU_TRUOC_THANG_DANG_XET * KET_THUC_TAI_THOI_DIEM_XET;
        // Bắt đầu trong tháng đang xét
        if (thang_bat_dau == thang_dang_xet && thang_ket_thuc == thang_dang_xet)
            return BAT_DAU_TRONG_THANG_DANG_XET * KET_THUC_TAI_THOI_DIEM_XET;
    }

    return 0;
}