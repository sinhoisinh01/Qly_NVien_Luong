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
    switch (dt.getMonth() + 1) {
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
 * Lấy hệ số lương của 1 nhân viên vào 1 ngày cụ thể
 * Return: 1 he_so_luong json object
 */
function getHeSoLuongByExactlyDay(ngachTable, day) {
    length = ngachTable.length;
    for (var i = 0; i < length; i++) {
        if (isRightHistory(ngachTable[i], day))
            return ngachTable[i].he_so_luong;
    }
    return null;
}

/*
 * Lấy chức vụ của 1 nhân viên vào 1 ngày cụ thể
 * Return: 1 chuc_vu json object
 */
function getChucVuByExactlyDay(chucVuTable, day) {
    chuc_vu_max = null;
    length = chucVuTable.length;
    // Lấy 1 dòng trong chucVuTable thỏa điều kiện làm Max
    for (var i = 0; i < length; i++) {
        if (isRightHistory(chucVuTable[i], day)) {
            chuc_vu_max = chucVuTable[i].chuc_vu;
            i = length;
        }
    }

    // Nếu tìm được 1 dòng như vậy, tìm chức vụ có hệ số lớn nhất
    if (chuc_vu_max != null) {
        for (var i = 0; i < length; i++) {
            if (isRightHistory(chucVuTable[i], day)) {
                if (chucVuTable[i].chuc_vu.he_so_chuc_vu > chuc_vu_max.he_so_chuc_vu) {
                    chuc_vu_max = chucVuTable[i].chuc_vu;
                    chuc_vu_max.don_vi = chucVuTable[i].don_vi;
                }
            }
        }
    }

    return chuc_vu_max;
}

/*
 * Tính lương của từng dòng theo công thức
 */
function getSalaryByExactlyDay(he_so_bac, vuot_khung, he_so_chuc_vu, luong_co_ban, day) {
    vuot_khung = vuot_khung == null ? 1.0 : vuot_khung;
    luong = (he_so_bac + he_so_chuc_vu) * luong_co_ban * vuot_khung;
    days = getDaysOfDate(day);

    return (luong / days);
}

/*
 * Tính lương từ ngày 1 đến thời điểm xét lương trong tháng
 */
function calculateSalary(ngachTable, chucVuTable, luong_co_ban, date) {
    numberOfDays = date.getDate();
    salaryObj = { salaryTable: [], totalSalary: 0 };
    for (var i = 1; i <= numberOfDays; i++) {
        dt = new Date(date.getFullYear(), date.getMonth(), i);
        he_so_luong = getHeSoLuongByExactlyDay(ngachTable, dt);
        chuc_vu = getChucVuByExactlyDay(chucVuTable, dt);

        if (he_so_luong != null && chuc_vu != null) {
            luong = getSalaryByExactlyDay(he_so_luong.he_so, he_so_luong.vuot_khung, chuc_vu.he_so_chuc_vu, luong_co_ban, dt);

            salaryObj.salaryTable.push({
                moment: dt,
                ngach: he_so_luong,
                chuc_vu: chuc_vu,
                luong_ngay: luong
            });
            salaryObj.totalSalary += luong;
        }
    }
    salaryObj.totalSalary = Math.ceil(salaryObj.totalSalary);
    return salaryObj;
}

/*
 * Kiểm tra dòng có hợp với thời điểm xét khôn
 */
function isRightHistory(row, thoi_diem_xet) {
    // Nếu ngày kết thức là hiện nay (null)
    if (row.ngay_ket_thuc == null) {
        // thoi_diem_xet nằm sau ngay_bat_dau
        if (thoi_diem_xet.valueOf() >= row.ngay_bat_dau.valueOf())
            return true;
        else
            return false;
    }
    else {
        // ngay_bat_dau <= thoi_diem_xet <= ngay_ket_thuc
        if (thoi_diem_xet.valueOf() >= row.ngay_bat_dau.valueOf() && thoi_diem_xet.valueOf() <= row.ngay_ket_thuc.valueOf())
            return true;
        else
            return false;
    }
}