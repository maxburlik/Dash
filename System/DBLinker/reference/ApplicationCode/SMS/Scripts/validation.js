
function validate_date1(date) {
    var date_format = /^(\d{1,2})(\/)(\d{1,2})(\/)(\d{4})$/;
    var is_valid_date = date.match(date_format);
    if (is_valid_date == null) {
        alert(date + " is not a correct format. Please use DD/MM/YYYY format");
        return false;
    }

    var month = is_valid_date[1];
    var day = is_valid_date[3];
    var year = is_valid_date[5];


    if (month < 1 || month > 12) {
        alert("Month must be between 1 and 12.");
        return false;
    }

    if (day < 1 || day > 31) {
        alert("Day must be between 1 and 31.");
        return false;
    }

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        switch (month) {
            case '04': month_name = 'April'; break;
            case '4': month_name = 'April'; break;
            case '06': month_name = 'June'; break;
            case '6': month_name = 'June'; break;
            case '09': month_name = 'September'; break;
            case '9': month_name = 'September'; break;
            case '11': month_name = 'November'; break;
            default: month_name = 'unknown';
        }
        alert(month_name + " doesn't have 31 days!")
        return false;
    }

    if (month == 2) {
        if (day > 29 || (day == 29 && !(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)))) {
            alert("February in " + year + " doesn't have " + day + " days!");
            return false;
        }
    }

    return true;
}

function validate_date2(date) {
    var date_format = /^(\d{1,2})(\/)(\d{1,2})(\/)(\d{4})$/;
    var is_valid_date = date.match(date_format);

    if (is_valid_date == null)
        return false;

    var month = is_valid_date[1];
    var day = is_valid_date[3];
    var year = is_valid_date[5];

    if (month < 1 || month > 12 || day < 1 || day > 31)
        return false;

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
        return false;

    if (month == 2)
        if (day > 29 || (day == 29 && !(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))))
            return false;


    return true;
}

function isValidNumber(number) {
    return /^\d+$/.test(number);
}

function isValidEmail(emailAddress) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[(2([0-4]\d|5[0-5])|1?\d{1,2})(\.(2([0-4]\d|5[0-5])|1?\d{1,2})){3} \])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    return re.test(emailAddress);
}

function isValidPhoneNumber(phoneNumber) {
    var re = /^\d{10,11}$/;
    return re.test(phoneNumber);
}

function isValidMedicalNumber(medicalNumber) {
    var re = /^\d{10}$/;
    return re.test(medicalNumber);
}

function isValidPostalCode(postalCode) {
    var re = /^\s*[a-ceghj-npr-tvxy]\d[a-ceghj-npr-tv-z](\s)?\d[a-ceghj-npr-tv-z]\d\s*$/i;
    return re.test(postalCode);
}