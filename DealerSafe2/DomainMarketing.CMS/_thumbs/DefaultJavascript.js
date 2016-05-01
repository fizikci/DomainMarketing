var getRatingText = function(number){
    if(number == 1) return "OK";
    if(number == 2) return "Fine";
    if(number == 3) return "Good";
    if(number == 4) return "Great";
    if(number == 5) return "Excellent";
    
    if(number == -1) return "Not OK";
    if(number == -2) return "Not Good";
    if(number == -3) return "Bad";
    if(number == -4) return "Very Bad";
    if(number == -5) return "Worst";
};

if(~location.href.indexOf('domainmarketing.com'))
    document.domain = "domainmarketing.com";
else if(~location.href.indexOf('kar-zarar.com'))
    document.domain = "kar-zarar.com";

var ajaxLog = {};
function callAPIMethod(method, data, successCallback, failCallback) {
    ajaxLog[method] = new Date();
    return $.ajax({
        url: "DealerSafeAPIBridgeHandler.ashx?method="+method,
        data: "data="+JSON.stringify(data),
        type: 'POST',
        dataType: "json",
        success: function (res) {
            //res = eval('('+TOB64.decode(res)+')');
            console.log(method + ': ' + (new Date() - ajaxLog[method]) + ' ms');
            if (res.IsError)
                (failCallback || defaultFailCallback)(res);
            else
                (successCallback || defaultSuccessCallback)(res.Data);
            
            
            console.log(method + '+callback: ' + (new Date() - ajaxLog[method]) + ' ms');
        },
        error: function (err) {
            alert(JSON.stringify(err, null, '\t'));
        }
    });
}

function defaultFailCallback(res) {
    var msg = trError(res.ErrorMessage);
    
    // var btn = '';
    // if(res.ErrorMessage.indexOf('Access denied') > -1)
    //     btn = '<a href="/Default.aspx" class="btn btn-success">' + langRes.HomePage + '</a>';
        
    sweetConfirm(null, {
        title: "Error",
        text: msg,
        type: "error",
        showCancelButton: false,
        buttonText: "OK",
        buttonType: "info"
    });
}

langRes.HomePage = currLang=='tr' ? 'Ana Sayfa' : 'Home';

function defaultSuccessCallback(res) {
    sweetAlert({
        title: "Error",
        text: JSON.stringify(res, null, '\t'),
        type: "error"
    });
}

function trError(msg){
    for(var i=0; i<apiErrors.length; i++){
        if(msg.indexOf(apiErrors[i][0]) == 0 && apiErrors[i][0].length == msg.length)
            return apiErrors[i][currLang=='tr' ? 1 : 2] || msg;
    }
    return msg;
}

function alertNice(msg, title, btn) {
    if (!title) title = document.title;
    if (msg[0] == '#') msg = $(msg).html();
    if ($('#alertNice').length)
        $('#alertNice').remove();
        
    var html = '';
    html += '<div class="modal fade" id="alertNice" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">';
    html += '  <div class="modal-dialog">';
    html += '    <div class="modal-content">';
    html += '      <div class="modal-header">';
    html += '        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>';
    html += '        <h4 class="modal-title">'+title+'</h4>';
    html += '      </div>';
    html += '      <div class="modal-body">';
    html += msg;
    html += '      </div>';
    html += '      <div class="modal-footer">';
    if (btn)
        html += btn;
    html += '        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>';
    html += '      </div>';
    html += '    </div>';
    html += '  </div>';
    html += '</div>';
    $('body').append(html);

    $('#alertNice').modal('show');
}
// Create Base64 Object
var TOB64={_keyStr:"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",encode:function(e){var t="";var n,r,i,s,o,u,a;var f=0;e=Base64._utf8_encode(e);while(f<e.length){n=e.charCodeAt(f++);r=e.charCodeAt(f++);i=e.charCodeAt(f++);s=n>>2;o=(n&3)<<4|r>>4;u=(r&15)<<2|i>>6;a=i&63;if(isNaN(r)){u=a=64}else if(isNaN(i)){a=64}t=t+this._keyStr.charAt(s)+this._keyStr.charAt(o)+this._keyStr.charAt(u)+this._keyStr.charAt(a)}return t},decode:function(e){var t="";var n,r,i;var s,o,u,a;var f=0;e=e.replace(/[^A-Za-z0-9\+\/\=]/g,"");while(f<e.length){s=this._keyStr.indexOf(e.charAt(f++));o=this._keyStr.indexOf(e.charAt(f++));u=this._keyStr.indexOf(e.charAt(f++));a=this._keyStr.indexOf(e.charAt(f++));n=s<<2|o>>4;r=(o&15)<<4|u>>2;i=(u&3)<<6|a;t=t+String.fromCharCode(n);if(u!=64){t=t+String.fromCharCode(r)}if(a!=64){t=t+String.fromCharCode(i)}}t=Base64._utf8_decode(t);return t},_utf8_encode:function(e){e=e.replace(/\r\n/g,"\n");var t="";for(var n=0;n<e.length;n++){var r=e.charCodeAt(n);if(r<128){t+=String.fromCharCode(r)}else if(r>127&&r<2048){t+=String.fromCharCode(r>>6|192);t+=String.fromCharCode(r&63|128)}else{t+=String.fromCharCode(r>>12|224);t+=String.fromCharCode(r>>6&63|128);t+=String.fromCharCode(r&63|128)}}return t},_utf8_decode:function(e){var t="";var n=0;var r=c1=c2=0;while(n<e.length){r=e.charCodeAt(n);if(r<128){t+=String.fromCharCode(r);n++}else if(r>191&&r<224){c2=e.charCodeAt(n+1);t+=String.fromCharCode((r&31)<<6|c2&63);n+=2}else{c2=e.charCodeAt(n+1);c3=e.charCodeAt(n+2);t+=String.fromCharCode((r&15)<<12|(c2&63)<<6|c3&63);n+=3}}return t}}
// form to json
$.fn.serializeObject = function()
{
    var o = {};
    var a = this.serializeArray();
    $.each(a, function() {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function shuffle(o){ //v1.0
    for(var j, x, i = o.length; i; j = Math.floor(Math.random() * i), x = o[--i], o[i] = o[j], o[j] = x);
    return o;
};

$(function(){
    $(".theme-link").click(function(){setTheme($(this));});
    markTheme();
    //since Bootstrap 3.3.0 tooltips now needs to be initialized by user code,
    //due to performance reasons
    $('[data-toggle="tooltip"]').tooltip();
});
function markTheme(){
    var currTheme = getCookie('theme') || 'Cyborg';
    $(".theme-link").parent().removeClass("active");
    $(".theme-link:contains('"+currTheme+"')").parent().addClass("active");    
}
function setTheme(elm){
    setCookie('theme', $(elm).text());
    $('#tema').attr('href','http://maxcdn.bootstrapcdn.com/bootswatch/3.2.0/'+$(elm).text().toLowerCase()+'/bootstrap.min.css');
    markTheme();
}

function panelHoverIn(elm) {
   $(elm).addClass("panel-primary");
}
function panelHoverOut(elm) {
   $(elm).removeClass("panel-primary");
}

var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
    , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
    , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
    , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name, filename) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }

        document.getElementById("dlink").href = uri + base64(format(template, ctx));
        document.getElementById("dlink").download = filename;
        document.getElementById("dlink").click();

    }
})();

var isMobile = {
    Android: function() {
        return navigator.userAgent.match(/Android/i);
    },
    BlackBerry: function() {
        return navigator.userAgent.match(/BlackBerry/i);
    },
    iOS: function() {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i);
    },
    Opera: function() {
        return navigator.userAgent.match(/Opera Mini/i);
    },
    Windows: function() {
        return navigator.userAgent.match(/IEMobile/i);
    },
    any: function() {
        return ((isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows()) && $(window).width() < 640);
    }
};

function prettyDate(time){
    var date = new Date((time || "").replace(/-/g,"/").replace(/[TZ]/g," ")),
        diff = (((new Date()).getTime() - date.getTime()) / 1000),
        day_diff = Math.floor(diff / 86400);
            
    if (isNaN(day_diff) || day_diff < 0)
		return (currLang=='tr'?'simdi':"just now");
    if(!isMobile.any()){
    	return day_diff == 0 && (
    			diff < 60 && (currLang=='tr'?'simdi':"just now") ||
    			diff < 120 && (currLang=='tr'?'1 dk önce':"1 minute ago") ||
    			diff < 3600 && Math.floor( diff / 60 ) + (currLang=='tr'?' dk önce':" minutes ago") ||
    			diff < 7200 && (currLang=='tr'?"1 saat önce":"1 hour ago") ||
    			diff < 86400 && Math.floor( diff / 3600 ) + (currLang=='tr'?' saat önce':" hours ago")) ||
    		day_diff == 1 && (currLang=='tr'?'dün':"yesterday") ||
    		day_diff < 7 && day_diff + (currLang=='tr'?' gün önce':" days ago") ||
    		day_diff < 31 && Math.floor( day_diff / 7 ) + (currLang=='tr'?' hafta önce':" weeks ago") ||
            day_diff < 365 && Math.floor( day_diff / 30 ) + (currLang=='tr'?' ay önce':" months ago") ||
            day_diff > 365 && Math.floor( day_diff / 365 ) + (currLang=='tr'?' yil önce':" year ago");
    } else { 
        return day_diff == 0 && (
    		diff < 60 && (currLang=='tr'?'simdi':"now") ||
    		diff < 120 && (currLang=='tr'?'1dk':"1m") ||
    		diff < 3600 && Math.floor( diff / 60 ) + (currLang=='tr'?'dk':"m") ||
    		diff < 7200 && (currLang=='tr'?"1 sa":"1 hr") ||
    		diff < 86400 && Math.floor( diff / 3600 ) + (currLang=='tr'?'s':"h")) ||
    	day_diff == 1 && (currLang=='tr'?'dün':"yesterday") ||
    	day_diff < 7 && day_diff + (currLang=='tr'?' gün':" days") ||
    	day_diff < 31 && Math.floor( day_diff / 7 ) + (currLang=='tr'?' hafta':" weeks") ||
        day_diff < 365 && Math.floor( day_diff / 30 ) + (currLang=='tr'?' ay':" months") ||
        day_diff > 365 && Math.floor( day_diff / 365 ) + (currLang=='tr'?' yil':" year");
    }
}
function scrollToBottom(el, scrollToEl){
    //$(el).css({ scrollTop: $(el)[0].scrollHeight});
    $(el).animate({ scrollTop: $(el)[0].scrollHeight}, 1);
}
function makeLink(text){
    var re = /(https?:\/\/(([-\w\.]+)+(:\d+)?(\/([\w/_\.]*(\?\S+)?)?)?))/g;
    return text.replace(re, "<a href=\"$1\" target=\"_blank\">$1</a>");
}

function queryString(name, val) {
    if(!val){
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
    else
    {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)");
        var urlWithoutQS = location.href.replace(regex, '');
        var afterDiyez = '';
        if(urlWithoutQS.indexOf('#')>-1){
            var withoutDiyez = urlWithoutQS.substring(0, urlWithoutQS.indexOf('#'))
            afterDiyez = urlWithoutQS.substring(urlWithoutQS.indexOf('#'));
            urlWithoutQS = withoutDiyez;
        }
        location.href = urlWithoutQS + (urlWithoutQS.indexOf('?')>-1 ? '&':'?') + name+'='+val + afterDiyez;
    }
}


function setLocationLang(l){
    
}

var apiErrors = [
    ["Passwords not match", "Girdiginiz sifre yanlis", "Password you entered is incorrect."],
	["Please enter a valid email address", "Lütfen geçerli bir email adresi giriniz. ", "Please enter a valid email address"],
	["No such member", "Böyle bir kullanici yok.", "No such username"],
	["Keyword required", "Anahtar kelime gerekli.", "Keyword required"],
	["No such member with the keyword provided", "Bu anahtar kelimeye kullnilmis.", "Keyword is outdated."],
	["Email address is invalid", "Email adresi geçersiz.", "Email address is invalid"],
	["Not valid email address", "Geçersiz email adresi.", "Invalid email address."],
	["Password length cannot be less than six", "Sifre en az 6 karakterden olusmalidir.", "Password should contain at least 6 characters."],
	["Not valid email address", "Email adresi geçersiz.", "Email address is invalid"],
	["Please type your name", "Lütfen isminizi giriniz.", "Please type your name"],
	["Please type your surname", "Lütfen soy isminizi giriniz.", "Please type your surname."],
	["Email adresi kullaniliyor. Lütfen baska bir email adresi giriniz.", "Bu email adresi kullaniliyor. Lütfen baska bir email adresi giriniz.", "This email address is already in use. Please select another email address"],
	["Invalid email or password",  "Geçersiz email adresi ya da sifre.", "Invalid email address or password"],
	["Access denied", "Erisim engellendi.", "Access is denied"],
	["Sinif seçiniz", "Sinif seçiniz.", "Select a class"],
	["Sinifa ders kitabi atanmamis", "Sinifa ders kitabi atanmamis.", "No coursebook is assigned to the class."],
	["Access is denied", "Erisim engellendi.", "Access is denied."],
	["Ders kitabi bulunamadi", "Ders kitabi bulunamadi.", "Coursebook not found."],
	["Mesaj giriniz", "Mesajinizi giriniz.", "Type your message."],
	["Bu mesaj kime gönderilecek?", "Mesaj göndereceginiz kisiyi seçniz.", "Select the person to whom this message will be sent."],
	["Son kullanma tarihi yanlis","Son kullanma tarihi yanlis", "Expiration date is incorrect."],
	["CCV2 kodu hatali","CCV2 kodu hatali", "CCV2 code is incorrect."],
	["Ödemenizin onaylanmasinda bir hata olustu.", "Ödemeniz onaylanirken bir hata olustu.", "An error occured while approving you payment."],
	["You cannot answer the activity you haven't seen yet", "Henüz görmediginiz bir etkinligi cevaplayamazsiniz.", "You cannot answer the activity you haven't seen yet."],
	["Kurum seçiniz", "Kurum seçiniz.", ""],
	["Lütfen ya ögretmen seçiniz ya da yeni ögretmen için email adresi giriniz.", "Lütfen ya ögretmen seçiniz ya da yeni ögretmen için email adresi giriniz.", "Please select a teacher or enter an email address for the new teacher."],
	["Bu kullanicinin tipi temsilci degil!", "Bu kullanici, temsilci degil.", "This username is not representative."],
	["Ülke seçiniz", "Ülke seçiniz.", "Select a country."],
	["Lütfen ya temsilci seçiniz ya da yeni temsilci için email adresi giriniz.", "", ""]
];
var toDashCase = function(s){
    return s.replace(/\.?([A-Z])/g, function (x,y){return "-" + y.toLowerCase()}).replace(/^_/, "");
};
/*
 * Input directives
*/


app.directive('inputFile', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            if (!attr.placeholder) attr.placeholder = '';
            var isAttrLoader = (typeof(attr.isUploading) === "undefined" ? false : true);
            var customAttrs = " " + Object.keys(attr)
                .filter(function(x){ return x.indexOf("custom") === 0; })
                .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            var events = Object.keys(attr).filter(function(el){ return el.startsWith("on") });
            
            var html = '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    elm.html() +
    (isAttrLoader ? '           <img ng-show="' + attr.isUploading + '" style="width: 100px" src="/userfiles/loading.gif" class="verticalMiddle">' : '') +
                    (elm.html().trim().length > 0 ? '<br ng-show="'+ attr.model +'.length > 0"><br ng-show="'+ attr.model +'.length > 0">' : '') +
                    '           <input type="file" ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '')
                                    + (isAttrLoader ? ' ng-disabled="' + attr.isUploading + '"' : '')
                                    + (attr.inputClass ? ' class="' + attr.inputClass + ' col-sm-10 col-xs-12"' : '')
                                    + (attr.multiple ? ' multiple' : '')
                                    + (attr.accept ? ' accept="' + attr.accept + '"' : '')
                                    + (attr.maxsize ? ' maxsize="' + attr.maxsize + '"' : '')
                                    + (attr.minsize ? ' minsize="' + attr.minsize + '"' : '')
                                    + (attr.minnum ? ' minnum="' + attr.minnum + '"' : '')
                                    + (attr.maxnum ? ' maxnum="' + attr.maxnum + '"' : '');
                                    for(var i = 0; i< events.length; i++){
                                        html += " " + toDashCase(events[i]) + '="' + attr[events[i]] + '"';
}
                                html += (attr.onAfterValidate ? ' on-after-validate="' + attr.onAfterValidate + '"' : '')
                                    + (attr.required ? ' required' : '')
                                    + customAttrs
                                    + ' base-sixty-four-input>' +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
            return html;
        }
    };
});
app.directive('formInput', function () {
    return {
        restrict: 'E',
        replace: false,
        template: function (elm, attr) {
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                                elm.html() +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputText', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            if (!attr.placeholder) attr.placeholder = '';
            var customAttrs = " " + Object.keys(attr)
                .filter(function(x){ return x.indexOf("custom") === 0; })
                .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    '           <input type="text" ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '') 
                                    + ' placeholder="' + attr.placeholder + '"' 
                                    + (attr.disabled?' disabled="'+attr.disabled+'"':'')
                                    + (attr.required ? ' required' : '')
                                    + customAttrs
                                    + ' class="col-sm-10 col-xs-12" />' +
                        elm.html() +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputPassword', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            if (!attr.placeholder) attr.placeholder = '';
                         var customAttrs = " " + Object.keys(attr)
                             .filter(function(x){ return x.indexOf("custom") === 0; })
                             .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    '           <input type="password" ng-model="' + attr.model + '"'
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '')
                                    + ' placeholder="' + attr.placeholder + '"'
                                    + (attr.disabled?' disabled="'+attr.disabled+'"':'')
                                    + (attr.required ? ' required' : '')
                                    + customAttrs
                                    + ' class="col-sm-10 col-xs-12" />' +
                        elm.html() +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputNumber', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
                         var customAttrs = " " + Object.keys(attr)
                             .filter(function(x){ return x.indexOf("custom") === 0; })
                             .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    '           <input type="number" ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '') 
                                    + (attr.disabled ? ' disabled="' + attr.disabled + '"' : '') 
                                    + (attr.required ? ' required' : '')
                                    + customAttrs
                                    + ' class="input-mini bkspinner ' + (attr.addClass ? attr.addClass : '') + '" />' +
                        elm.html() +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputTextarea', function () {
    return {
        restrict: 'E',
        replace: true,
    	link: function(scope, elem, attrs){
			if(attrs.htmlEdit)
				$(elem).find('.ww').ace_wysiwyg({
					toolbar:
					[
						{name:'bold', className:'btn-info'},
						{name:'italic', className:'btn-info'},
						{name:'strikethrough', className:'btn-info'},
						{name:'underline', className:'btn-info'},
						null,
						{name:'insertTable', className: 'btn-success' },
						{name:'insertunorderedlist', className: 'btn-success' },
						{name:'insertorderedlist', className: 'btn-success' },
						{name:'outdent', className:'btn-purple'},
						{name:'indent', className:'btn-purple'},
						null,
						{name:'justifyleft', className:'btn-primary'},
						{name:'justifycenter', className:'btn-primary'},
						{name:'justifyright', className:'btn-primary'},
						null,
						'viewSource'
					],
					'wysiwyg': {
						fileUploadError: function(){}
					}
				}).prev().addClass('wysiwyg-style2');
		},
        template: function (elm, attr) {
                         var customAttrs = " " + Object.keys(attr)
                             .filter(function(x){ return x.indexOf("custom") === 0; })
                             .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
  (!attr.htmlEdit ? '           <textarea ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '') 
                                    + (attr.style ? ' style="'+attr.style+'"' : '') 
                                    + (attr.disabled ? ' disabled="' + attr.disabled + '"' : '') 
                                    + (attr.required ? ' required' : '') 
                                    + customAttrs
                                    + ' class="col-sm-10 col-xs-12" rows="3"></textarea>' : '') +
   (attr.htmlEdit ? '			<div style="height:200px" class="ww"' + (attr.name ? ' name="' + attr.name + '"' : '') 
                                    + (attr.required ? ' required' : '') 
                                    + customAttrs
                                    + ' ng-bind-html="' + attr.model + '" class="col-sm-10 col-xs-12"></div>' : '') +
                        elm.html() +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputSelect', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            var horizontal = attr.horizontal;
            var customAttrs = " " + Object.keys(attr)
                .filter(function(x){ return x.indexOf("custom") === 0; })
                .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            var res =
            (!horizontal ? '<div>' : '') +
                (!horizontal ? '   <div class="space-4"></div>' : '') +
                '   <div class="form-group">' +
                '       <label for="' + attr.name + '" class="' + (horizontal ? '' : 'col-sm-3') + ' control-label no-padding-right"> ' + attr.label + ' </label>' +
                '       <div' + (horizontal ? '' : ' class="col-sm-9"') + '>' +
                '           <select' + (attr.name ? ' id="' + attr.name + '"' : '') 
                                + ' ng-model="' + attr.model 
                                + '" ng-options="' + attr.options + '"' 
                                + (attr.change ? ' ng-change="' + attr.change + '"' : '') 
                                + (horizontal ? '' : ' class="col-sm-10 col-xs-12"') 
                                + (attr.disabled?' disabled="'+attr.disabled+'"':'') 
                                + (attr.required?' required':'') 
                                + customAttrs
                            + '>' 
                                + (attr.noEmptyOption ? '' : '<option value="" class=""></option>') +
                '           </select>' +
                '           <input type="text" style="display:none" ng-model="' + attr.model + '"' 
                                + (attr.name ? ' name="' + attr.name + '"' : '') 
                                + ' />' +
                elm.html() +
                (attr.required ? ' <span class="required-star">*</span> ' : '') +
                '       </div>' +
                '   </div>' +
                (!horizontal ? '</div>' : '');
            return res;
        }
    };
});
app.directive('inputDatePicker', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            if (!attr.placeholder) attr.placeholder = '';
                var customAttrs = " " + Object.keys(attr)
                    .filter(function(x){ return x.indexOf("custom") === 0; })
                    .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    '           <input type="date" ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '') 
                                    + (attr.required ? ' required' : '')
                                    + (attr.disabled ? ' disabled="' + attr.disabled + '"' : '') 
                                    + customAttrs
                                    + '/>' +
                                (attr.required ? ' <span class="required-star">*</span> ' : '') +
                                elm.html() +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        },
        link: function (scope, element, attrs, controllers) {
            setTimeout(function () {
                var v = element.find('input').val();
                if (v.indexOf('T') > -1)
                    element.find('input').val(v.split('T')[0]);
            }, 200);
            //element.find(".date-picker").datepicker();
        }
    };
});
app.directive('inputCheck', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
                         var customAttrs = " " + Object.keys(attr)
                             .filter(function(x){ return x.indexOf("custom") === 0; })
                             .map(function(x){ return x.replace("custom","") + "='" + attr[x] + "'" }).join(" ");
            if (!attr.placeholder) attr.placeholder = '';
            return '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                    '           <input type="checkbox" ng-model="' + attr.model + '"' 
                                    + (attr.name ? ' name="' + attr.name + '" id="' + attr.name + '"' : '') 
                                    + (attr.disabled ? ' disabled="' + attr.disabled + '"' : '') 
                                    + customAttrs
                                    + ' class="ace ace-switch ace-switch-5" />' +
                    '           <span class="lbl"></span>' +
                        elm.html() +
                        (attr.required ? ' <span class="required-star">*</span> ' : '') +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
        }
    };
});
app.directive('inputRadio', function () {
    return {
        restrict: 'E',
        replace: true,
        template: function (elm, attr) {
            var result = '<div>' +
                    '<div class="space-4"></div>' +
                        '<div class="form-group">' +
                        '<label class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                            '<div class="col-sm-9">' + 
                                '<label ng-repeat="n in '+attr.options+'">'+
                                    '<input type="radio" name="' + attr.name + '" ng-model="'+attr.model+'" ng-value="n.Id" /> {{n.Name}}'+
                                '</label> ';
          result += '       </div>' +
                    '   </div>' +
                    '</div>';
            return result;
        }
    };
});
app.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
});
app.filter('range', function() {
  return function(input, total) {
    total = parseInt(total);
    for (var i=1; i<=total; i++)
      input.push(i);
    return input;
  };
});
app.directive('errSrc', function() {
  return {
    link: function(scope, element, attrs) {
      element.bind('error', function() {
        if (attrs.src != attrs.errSrc) {
          attrs.$set('src', attrs.errSrc);
        }
      });
      
      attrs.$observe('ngSrc', function(value) {
        if (!value && attrs.errSrc) {
          attrs.$set('src', attrs.errSrc);
        }
      });
    }
  }
});
app.directive('inputDate', function ($compile, $filter) {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            model: "=",
            dateoptions: "=",
            maxYearOffset: "=?"
        },
        template: function (elm, attr) {
            var html = '<div>' +
                    '   <div class="space-4"></div>' +
                    '   <div class="form-group">' +
                    '       <label for="' + attr.name + '" class="col-sm-3 control-label no-padding-right"> ' + attr.label + ' </label>' +
                    '       <div class="col-sm-9">' +
                                '<input type="text" name="'+attr.name+'" class="'+ attr.inputClass +'"' + 
                                ' uib-datepicker-popup="{{dateFormat}}" ng-click="open()"  ng-model="'+attr.model+'"'+
                                ' is-open="popup.opened" datepicker-options="datepickerOptions"/>' +
                                elm.html() +
                    '       </div>' +
                    '   </div>' +
                    '</div>';
            return html;
        },
        link: {
            pre: function(scope, element, attrs, controller, transcludeFn)
            {
                // defaults
                if(!scope.model) scope.model = new Date();
                if(!scope.maxYearOffset) scope.maxYearOffset = 4;
                
                scope.dateFormat = "yyyy-MM-dd";
                var d = new Date();
                scope.datepickerOptions = {
                    maxDate: new Date(d.getFullYear() + scope.maxYearOffset, d.getMonth(), d.getDate()),
                    minDate: new Date(1900, 1, 1),
                    startingDay: 1,
                    showWeeks: false,
                    initDate: scope.model
                };
            },
            post: function(scope, element, attrs, controller, transcludeFn)
            {
                var d = $filter('date')(scope.datepickerOptions.initDate, scope.dateFormat);
                setTimeout(function(){
                    $(element.find("input")).val(d);
                }, 100);
                scope.open = function() {
                    scope.popup.opened = true;
                };
            
                scope.popup = {
                    opened: false
                };
            }
        }
    };
});