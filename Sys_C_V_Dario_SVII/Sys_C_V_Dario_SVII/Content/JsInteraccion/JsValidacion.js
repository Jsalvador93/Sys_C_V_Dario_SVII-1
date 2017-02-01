var vocales = "áéíóúÁÉÍÓÚ" ;
function fn_Validate_ID_06_RUC(Ruc) {
    var valMutiply = [5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 0 /* :v */];
    var accEval = 0;
    for (var i = 0 ; i < 11 ; i++) {
        accEval += parseInt(Ruc[i]) * valMutiply[i];
    }
    return parseInt( Ruc[ 10 ] ) == ( 11 - ( accEval - parseInt( accEval / 11 ) * 11 ) ) ;
}
//validar nombres y apellidos
function fn_Validate_ID_05(Element) {
    return ( Element > 64 && Element < 91 ) || ( Element > 96 && Element < 123 ) || (Element == 39) || fn_Contains( Element , vocales )  ;
}

function fn_Validate_Min_NumEntero( evt , Element) {
    var len = Elemnt.length;
    var keycode = evt.which;
    var schar = String.fromCharCode(keycode);
    if( len == 0 )
    return Element != 45 && ( Element > 47 && Element < 58 )
}

function fn_Validate_Num(evt, Element) {
    console.log(Element + "");
    var keycode = parseInt(evt.which);
    console.log(keycode);
    var schar = String.fromCharCode(keycode);
    var len = Element.length;
    if (len == 0) {
        if (schar == '.') return true;
        if (keycode > 47 && keycode < 58) return true;
    }
    if (!fn_contains(Element, ".") && schar == '.') return true;
    if (keycode > 47 && keycode < 58) return true;
    console.log("aeiou");
    return false;
}


function fn_Contains(a, b) {
    var lena = a.length, lenb = b.length;
    for (var i = 0 ; i + lenb - 1 < lena ; i++) {
        var j = 0;
        for (; j < lenb ; j++) {
            if (a[i + j] != b[j]) break;
        }
        if (j == lenb) return true;
    }
    return false;
}


