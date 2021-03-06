﻿app.service('entityService', function () {

    var url = "/Staff/Handlers/CRUDHandler.ashx?entityName=_ENTITY_NAME_";

    var diz = this;

    this.get = function (entityName, id, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), callback, { method: "GetById", id: id });
    };

    this.getForEdit = function (entityName, id, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), callback, { method: "GetByIdForEdit", id: id });
    };

    this.getList = function (entityName, pageSize, pageNo, callback, where, orderBy) {
        var postData = { method: "GetList", pageSize: pageSize, pageNo: pageNo };
        if (where) postData["Where"] = where;
        if (orderBy) postData["OrderBy"] = orderBy;

        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), function (list) {
            if (callback) callback(list);
        }, postData);
    };


    this.getIdNameList = function (entityName, pageSize, pageNo, callback, where, orderBy) {
        var postData = { method: "GetIdNameList", pageSize: pageSize, pageNo: pageNo };
        if (where) postData["Where"] = where;
        if (orderBy) postData["OrderBy"] = orderBy;

        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), function (list) {
            if (callback) callback(list);
        }, postData);
    };

    this.delete = function (entityName, entity, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), function () {
            if (callback) callback();
        }, { method: "DeleteById", id: entity.Id });
    };

    this.undelete = function (entityName, entity, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), function () {
            if (callback) callback();
        }, { method: "UndeleteById", id: entity.Id });
    };

    this.save = function (entityName, data, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName) + '&method=SaveWithAjax', function (entity) {
            if (callback) callback(entity);
        }, data);
    };
    this.update = function (entityName, data, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName) + '&method=UpdateWithAjax', function (entity) {
            if (callback) callback(entity);
        }, data);
    };
    this.insert = function (entityName, data, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName) + '&method=InsertWithAjax', function (entity) {
            if (callback) callback(entity);
        }, data);
    };

    this.moveUp = function (entityName, id, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), callback, { method: "MoveUp", id: id });
    };
    this.moveDown = function (entityName, id, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', entityName), callback, { method: "MoveDown", id: id });
    };

    this.copy = function (entityName, data, callback) {
        data.Id = '';
        diz.save(entityName, data, callback);
    };


    this.getEnumList = function (enumName, callback) {
        doAjaxCall(url.replace('_ENTITY_NAME_', 'Member'), function (list) {
            if (callback) callback(list);
        }, { method: "GetEnumList", enumName: enumName });
    };

});

function doAjaxCall(url, callback, postData) {
    $.ajax({
        type: "POST",
        url: url,
        data: postData,
        cache: false,
        timeout: 20 * 1000,
        beforeSend: function () {
            //todo: show loading
        },
        complete: function () {
            //todo: hide loading
        },
        success: function (res) {
            if (res.isError) {
                alert(res.errorMessage);
                if (res.errorMessage.indexOf('denied') > -1)
                    location.href = '/Staff/Login.aspx';
                return;
            }

            if (callback) callback(res.data);
        },
        error: function (msg, t) {
            if (msg && !msg.isError) {
                var d = eval('(' + msg.responseText + ')');
                callback(d.data);
                return;
            }

            if (msg.statusText.indexOf('denied') > -1)
                location.href = '/Staff/Login.aspx';

            alert("HATA: " + msg.statusText);
        }
    });
}

function checkId(entityName, id, callbackExist, callbackNonexist) {
    doAjaxCall('/Staff/Handlers/CRUDHandler.ashx?entityName=' + entityName, function (res) {
        if (res)
            callbackExist();
        else
            callbackNonexist();
    }, { method: "CheckId", id: id });
};