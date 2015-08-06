var defaultListController = function ($scope, $routeParams, entityService) {

    if (!$scope.entityName) $scope.entityName = $routeParams.entityName;
    if ($scope.orderBy == undefined) $scope.orderBy = 'InsertDate';
    if ($scope.orderByAsc == undefined) $scope.orderByAsc = false;
    if ($scope.pageSize == undefined) $scope.pageSize = 20;
    $scope.filter = {};
    if ($routeParams.where) {
        $scope.where = $routeParams.where;
        var parts = $routeParams.where.split(' AND ');
        for (var i = 0; i < parts.length; i++) {
            var keyVal = parts[i].split(' = ');
            $scope.filter[keyVal[0]] = keyVal[1];
        }
    }

    $scope.count = 20;

    if (!$scope.search)
        $scope.search = function () { $scope.getPage(0); };

    if (!$scope.tryFirstSearchCounter) $scope.tryFirstSearchCounter = 0;
    $scope.tryFirstSearch = function () {
        $scope.tryFirstSearchCounter--;
        if ($scope.tryFirstSearchCounter == 0)
            $scope.search();
    };

    if ($routeParams.where)
        $scope.where = $routeParams.where;

    $scope.setPages = function () {
        var pages = [];
        for (var i = Math.max(0, $scope.currPage - 4) ; i <= Math.min(Math.ceil($scope.count / $scope.pageSize) - 1, $scope.currPage + 4) ; i++)
            pages.push(i);
        $scope.pages = pages;
    };

    if (!$scope.getPage)
        $scope.getPage = function (pageNo) {
            if (pageNo != 0 && (pageNo < 0 || pageNo > Math.ceil($scope.count / $scope.pageSize) - 1))
                return;

            entityService.getList($scope.entityName, $scope.pageSize, pageNo, function (res) {
                $scope.$apply(function () {
                    $scope.list = res.list;
                    $scope.count = res.count;
                    $scope.currPage = pageNo;
                    $scope.setPages();
                });
            }, $scope.where, $scope.orderBy + ($scope.orderByAsc ? '' : ' desc'));
        };

    $scope.setOrderBy = function (f) {
        if ($scope.orderBy == f) {
            $scope.orderByAsc = !$scope.orderByAsc;
        } else {
            $scope.orderBy = f;
            $scope.orderByAsc = true;
        }
        $scope.getPage(0);
    };

    $scope.isOrderBy = function (f) {
        return $scope.orderByAsc && $scope.orderBy == f;
    };
    $scope.isOrderByDesc = function (f) {
        return !$scope.orderByAsc && $scope.orderBy == f;
    };

    $scope.delete = function (entity) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete($routeParams.entityName, entity, function () {
                $scope.$apply(function () {
                    entity.IsDeleted = true;
                });
            });
    };
    $scope.undelete = function (entity) {
        if (confirm('It\'s gonna be undeleted.'))
            entityService.undelete($routeParams.entityName, entity, function () {
                $scope.$apply(function () {
                    entity.IsDeleted = false;
                });
            });
    };

    if ($scope.tryFirstSearchCounter == 0)
        $scope.search();
};
var defaultEditController = function ($scope, $routeParams, entityService) {

    if (!$scope.entityName) $scope.entityName = $routeParams.entityName;
    if (!$scope.entityId) $scope.entityId = $routeParams.Id;

    if ($scope.entityId)
        entityService.getForEdit($scope.entityName, $scope.entityId, function (entity) {
            $scope.$apply(function () {
                $scope.entity = entity;

                if ($scope.getFunc) $scope.getFunc();
            });
        });

    $scope.save = function () {
        var ent = $scope.entity;
        $('.ww').each(function () {
            ent[$(this).attr('name')] = $(this).html();
        });
        if ($scope.entityId)
            entityService.update($scope.entityName, $scope.entity, function (e) {
                if ($scope.afterSave)
                    $scope.afterSave(e);
                else
                    location.href = '#/List/' + $scope.entityName;
            });
        else
            entityService.insert($scope.entityName, $scope.entity, function (e) {
                if ($scope.afterSave)
                    $scope.afterSave(e);
                else
                    location.href = '#/List/' + $scope.entityName;
            });
    };
    $scope.cancel = function () {
        location.href = '#/List/' + $scope.entityName;
    };
};
var defaultViewController = function ($scope, $routeParams, entityService) {

    if (!$scope.entityName)
        $scope.entityName = $routeParams.entityName;

    entityService.get($scope.entityName, $routeParams.Id, function (entity) {
        $scope.$apply(function () {
            $scope.entity = entity;

            for (var cs = $scope.$$childHead; cs; cs = cs.$$nextSibling) {
                if (cs.getPage) {
                    cs.where += entity.Id;
                    cs.getPage(0);
                }
            }

            if ($scope.getFunc) $scope.getFunc();
        });
    });

    $scope.delete = function () {
        if (confirm('Kayıt silinecek!'))
            entityService.delete($scope.entityName, $scope.entity, function () {
                $scope.$apply(function () {
                    $scope.entity.Visible = false;
                });
            });
    };

    $scope.undelete = function () {
        if (confirm('Arşivden çıkarılacak!'))
            entityService.undelete($scope.entityName, $scope.entity, function () {
                $scope.$apply(function () {
                    $scope.entity.Visible = true;
                });
            });
    };
    $scope.toggleDelete = function () {
        if ($scope.entity.Visible)
            $scope.delete();
        else
            $scope.undelete();
    };

    $scope.copy = function () {
        entityService.copy($scope.entityName, $scope.entity, function (e) {
            location.href = '#/Edit/' + $scope.entityName + '/' + e.Id;
        });
    };

};

app.controller('ListViewEntityLocaleAllController', function ($scope, $routeParams, entityService) {

    $scope.orderBy = 'EntityName';

    $scope.search = function () {
        $scope.where = setCriteriaValue($scope.where, 'EntityName', $scope.filter.EntityName);
        $scope.where = setCriteriaValue($scope.where, 'FieldName', $scope.filter.FieldName);
        $scope.getPage(0);
    };

    $scope.EntityNameList = [{ Id: 'CCMessageTemplate', Name: 'Message Template' }];
    $scope.FieldNameList = [{ Id: 'Name', Name: 'Adı' }, { Id: 'Description', Name: 'Açıklaması' }];

    defaultListController($scope, $routeParams, entityService);

    $scope.edit = function (e, langName, langId) {
        var html = '<textarea id="loc" style="width:500px;height:200px">' + (e[langName] || '') + '</textarea><br/>'
        alertNice(html, '', '<button id="btnKydt" type="button" class="btn btn-success" data-dismiss="modal">Kaydet</button>');

        e.langName = langName;
        e.langId = langId;

        $('#btnKydt').click(function () {
            e[langName] = $('#loc').val();
            doAjaxCall('/Staff/Handlers/DoCommand.ashx?method=saveLocale', function (entity) { location.reload(); }, e);
        });
    }
});

var viewDetailListController = function ($scope, $routeParams, entityService) {
    //if (($scope.orderBy)!== null) $scope.orderBy = 'OrderNo';
    if (!$scope.orderBy) $scope.orderBy = 'Id';
    $scope.orderByAsc = true;
    if (!$scope.pageSize) $scope.pageSize = 20;
    $scope.count = 20;

    $scope.setPages = function () {
        var pages = [];
        for (var i = Math.max(0, $scope.currPage - 4) ; i <= Math.min(Math.ceil($scope.count / $scope.pageSize) - 1, $scope.currPage + 4) ; i++)
            pages.push(i);
        $scope.pages = pages;
    };

    $scope.getPage = function (pageNo) {
        if (!$scope.entityName)
            return;
        if (pageNo < 0 || pageNo > Math.ceil($scope.count / $scope.pageSize) - 1)
            return;

        entityService.getList($scope.entityName, $scope.pageSize, pageNo, function (res) {
            $scope.$apply(function () {
                $scope.list = res.list;
                $scope.count = res.count;
                $scope.currPage = pageNo;
                $scope.setPages();
            });
        }, $scope.where, $scope.orderBy + ($scope.orderByAsc ? '' : ' desc'));
    };

    $scope.setOrderBy = function (f) {
        if ($scope.orderBy == f) {
            $scope.orderByAsc = !$scope.orderByAsc;
        } else {
            $scope.orderBy = f;
            $scope.orderByAsc = true;
        }
        $scope.getPage(0);
    };

    $scope.isOrderBy = function (f) {
        return $scope.orderByAsc && $scope.orderBy == f;
    };
    $scope.isOrderByDesc = function (f) {
        return !$scope.orderByAsc && $scope.orderBy == f;
    };

    $scope.delete = function (entity) {
        if (confirm('Kayıt silinecek!'))
            entityService.delete($scope.entityName, entity, function () {
                $scope.$apply(function () {
                    $scope.getPage($scope.currPage);
                });
            });
    };

    //$scope.$watch('pageSize', function (v) { $scope.getPage(0); });
};
var viewDetailEditController = function ($scope, $routeParams, entityService) {

    if (!$scope.entityName) alert("set entityName for viewDetailEdit");
    if (!$scope.entityId) alert("set entityId for viewDetailEdit");

    entityService.getForEdit($scope.entityName, $scope.entityId, function (entity) {
        $scope.$apply(function () {
            $scope.entity = entity;
            if ($scope.getFunc) $scope.getFunc();
        });
    });

    $scope.save = function () {
        if ($scope.entity.Id)
            entityService.update($scope.entityName, $scope.entity, function (e) {
                alert("ok");
            });
        else {
            $scope.entity.Id = $scope.entityId;
            entityService.save($scope.entityName, $scope.entity, function (e) {
                alert("ok");
            });
        }
    };
    $scope.cancel = function () {
        location.href = '#/List/' + $scope.entityName;
    };
};
app.controller('ViewDetailListController', viewDetailListController);
app.controller('ViewDetailEditController', viewDetailEditController);

app.controller('ListJobController', function ($scope, $routeParams, entityService) {
    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedExecuter) $scope.where += ($scope.where ? ' AND ' : '') + 'Executer = ' + $scope.selectedExecuter;
        if ($scope.selectedState) $scope.where += ($scope.where ? ' AND ' : '') + 'State = ' + $scope.selectedState;
        if ($scope.selectedCommand) $scope.where += ($scope.where ? ' AND ' : '') + 'Command = ' + $scope.selectedCommand;

        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 3;

    entityService.getEnumList('JobStates', function (list) {
        $scope.$apply(function () {
            $scope.StateList = list;
            $scope.tryFirstSearch();
        });
    });
    entityService.getEnumList('JobExecuters', function (list) {
        $scope.$apply(function () {
            $scope.ExecuterList = list;
            $scope.tryFirstSearch();
        });
    });
    entityService.getEnumList('JobCommands', function (list) {
        $scope.$apply(function () {
            $scope.CommandList = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);
});

app.controller('ListMemberController', function ($scope, $routeParams, entityService) {
    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedMemberType) $scope.where += ($scope.where ? ' AND ' : '') + 'MemberType = ' + $scope.selectedMemberType;
        if ($scope.selectedState) $scope.where += ($scope.where ? ' AND ' : '') + 'State = ' + $scope.selectedState;

        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 2;

    entityService.getEnumList('MemberStates', function (list) {
        $scope.$apply(function () {
            $scope.StateList = list;
            $scope.tryFirstSearch();
        });
    });
    entityService.getEnumList('MemberTypes', function (list) {
        $scope.$apply(function () {
            $scope.MemberTypeList = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);
});
app.controller('EditMemberController', function ($scope, $routeParams, entityService) {
    $scope.getFunc = function () {
        entityService.getIdNameList('MemberAddress', 200, 0, function (list) {
            $scope.$apply(function () {
                $scope.Addresses = list;
            });
        }, "MemberId = " + $scope.entity.Id);

        entityService.getIdNameList('Language', 200, 0, function (list) {
            $scope.$apply(function () {
                $scope.Languages = list;
            });
        });
    };
    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewMemberController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('NewsletterDefinition', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.newsletterOptions = list;
        });
    });

    entityService.getIdNameList('Role', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.roleOptions = list;
        });
    });

    entityService.getEnumList('AddressTypes', function (list) {
        $scope.$apply(function () {
            $scope.addressTypes = list;
        });
    });

    entityService.getList('MemberAddress', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.addresses = res.list;
        });
    }, "MemberId = " + $routeParams.Id);

    entityService.getList('MemberBankAccount', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.banks = res.list;
        });
    }, "MemberId = " + $routeParams.Id);

    entityService.getList('MemberNewsletter', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.newsletters = res.list;
        });
    }, "MemberId = " + $routeParams.Id);

    entityService.getList('CrmActivity', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.tickets = res.list;
        });
    }, "MemberId = " + $routeParams.Id, 'InsertDate desc');

    entityService.getList('MemberRole', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.roles = res.list;
        });
    }, "MemberId = " + $routeParams.Id);

    entityService.get('Member', $routeParams.Id, function (entity) {
        $scope.$apply(function () {
            $scope.m = entity;
        });
    });

    $scope.tab = 'Tickets';

    entityService.getIdNameList('Country', 1000, 0, function (list) {
        $scope.$apply(function () {
            $scope.countries = list;
        });
    });

    $scope.getCities = function () {
        var filter = null;
        if ($scope.currAddr && $scope.currAddr.CountryId)
            filter = "CountryId = " + $scope.currAddr.CountryId;

        entityService.getIdNameList('City', 1000, 0, function (list) {
            $scope.$apply(function () {
                $scope.cities = list;
            });
        }, filter);
    };


    $scope.editAddress = function (a) {
        $scope.currAddr = a;
        if (a.CountryId) $scope.getCities();
    };
    $scope.newAddress = function () {
        $scope.currAddr = { MemberId: $routeParams.Id, };
    };
    $scope.deleteAddress = function (a) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("MemberAddress", a, function () {
                $scope.$apply(function () {
                    a.IsDeleted = true;
                });
            });
    };
    $scope.cancelEditAddress = function () {
        $scope.currAddr = null;
    };
    $scope.saveAddress = function () {
        var isNew = !$scope.currAddr.Id;
        entityService.save("MemberAddress", $scope.currAddr, function (ca) {
            $scope.$apply(function () {
                if (isNew)
                    $scope.addresses.push(ca);
                else
                    $scope.addresses[$scope.addresses.indexOf($scope.currAddr)] = ca;
                $scope.currAddr = null;
            });
        });
    };

    $scope.deleteNewsletter = function (n) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("MemberNewsletter", n, function () {
                $scope.$apply(function () {
                    n.IsDeleted = true;
                });
            });
    };
    $scope.addNewsletter = function () {
        entityService.save("MemberNewsletter", { NewsletterDefinitionId: $scope.selectedNewsletterOption.Id, MemberId: $scope.m.Id }, function (mn) {
            $scope.$apply(function () {
                mn.NewsletterDefinitionName = $scope.selectedNewsletterOption.Name;
                $scope.newsletters.push(mn);
            });
        });
    };

    $scope.deleteRole = function (r) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("MemberRole", r, function () {
                $scope.$apply(function () {
                    r.IsDeleted = true;
                });
            });
    };
    $scope.addRole = function () {
        entityService.save("MemberRole", { RoleId: $scope.selectedRoleOption.Id, MemberId: $scope.m.Id }, function (mr) {
            $scope.$apply(function () {
                mr.Name = $scope.selectedRoleOption.Name;
                $scope.roles.push(mr);
            });
        });
    };

    $scope.editBank = function (a) {
        $scope.currBank = a;
    };
    $scope.newBank = function () {
        $scope.currBank = { MemberId: $routeParams.Id, };
    };
    $scope.deleteBank = function (a) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("MemberBankAccount", a, function () {
                $scope.$apply(function () {
                    a.IsDeleted = true;
                });
            });
    };
    $scope.cancelEditBank = function () {
        $scope.currBank = null;
    };
    $scope.saveBank = function () {
        var isNew = !$scope.currBank.Id;
        entityService.save("MemberBankAccount", $scope.currBank, function (ca) {
            $scope.$apply(function () {
                if (isNew)
                    $scope.banks.push(ca);
                else
                    $scope.banks[$scope.banks.indexOf($scope.currBank)] = ca;
                $scope.currBank = null;
            });
        });
    };

    $scope.setBasket = function () {
        entityService.getList('Order', 1, 0, function (res) {
            $scope.$apply(function () {
                if (res.list.length) {
                    $scope.basket = res.list[0];
                    entityService.getList('OrderItem', 1000000, 0, function (r) {
                        $scope.$apply(function () {
                            $scope.basket.Items = r.list;
                        });
                    }, 'OrderId = ' + $scope.basket.Id);
                }
                if (!$scope.products) {
                    entityService.getList('Product', 1000000, 0, function (r) {
                        $scope.$apply(function () {
                            $scope.products = r.list;
                        });
                    });
                }
            });
        }, "MemberId = " + $routeParams.Id + ' AND State = Basket');
    };
    $scope.setBasket();
    $scope.getPrices = function () {
        entityService.getList('ProductPrice', 1000000, 0, function (r) {
            $scope.$apply(function () {
                $scope.prices = r.list;
            });
        }, 'ProductId = ' + $scope.selectedBasketProduct);
    };
    $scope.addToBasket = function () {
        entityService.save('OrderItem', { ProductPriceId: $scope.selectedBasketPrice, OrderId: $scope.basket.Id }, function (e) {
            $scope.setBasket();
        });
    };
    $scope.removeFromBasket = function (item) {
        entityService.delete('OrderItem', item, function () {
            $scope.$apply(function () {
                $scope.setBasket();
            });
        });
    };
});

app.controller('EditProductTypeController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('LifeCycle', 200, 0, function (list) {
        $scope.$apply(function () {
            $scope.LifeCycles = list;
        });
    });
    entityService.getIdNameList('PropertySet', 200, 0, function (list) {
        $scope.$apply(function () {
            $scope.PropertySets = list;
        });
    });


    defaultEditController($scope, $routeParams, entityService);
});

app.controller('ViewPropertySetController', function ($scope, $routeParams, entityService) {

    $scope.getFunc = function () {
        $scope.readProps();
    };

    $scope.tab = 'props';

    defaultViewController($scope, $routeParams, entityService);

    $scope.readProps = function () {
        entityService.getList('Property', 20, 0, function (res) {
            $scope.$apply(function () {
                $scope.props = res.list || [];
            });
        }, "PropertySetId = " + $scope.entity.Id, 'OrderNo');
    };

    $scope.min = function (arr) {
        return Math.min.apply(Math, arr.map(function (e) { return e.OrderNo; }));
    }

    $scope.editProp = function (a) {
        $scope.currProp = a;
    };
    $scope.newProp = function () {
        $scope.currProp = { PropertySetId: $scope.entity.Id };
    };
    $scope.deleteProp = function (pp) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("Property", pp, function () {
                $scope.$apply(function () {
                    pp.IsDeleted = true;
                });
            });
    };
    $scope.cancelEditProp = function () {
        $scope.currProp = null;
    };
    $scope.saveProp = function () {
        var isNew = !$scope.currProp.Id;
        entityService.save("Property", $scope.currProp, function (pp) {
            $scope.$apply(function () {
                if (!$scope.props) $scope.props = [];

                if (isNew)
                    $scope.props.push(pp);
                else
                    $scope.props[$scope.props.indexOf($scope.currProp)] = pp;
                $scope.currProp = null;
            });
        });
    };
    $scope.upProp = function (pp) {
        entityService.moveUp("Property", pp.Id, function (pp) {
            $scope.readProps();
        });
    }
    $scope.downProp = function (pp) {
        entityService.moveDown("Property", pp.Id, function (pp) {
            $scope.readProps();
        });
    }
});

app.controller('ListProductController', function ($scope, $routeParams, entityService) {
    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedProductType) $scope.where += ($scope.where ? ' AND ' : '') + 'ProductTypeId = ' + $scope.selectedProductType;

        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 1;

    entityService.getIdNameList('ProductType', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.ProductTypes = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);
});
app.controller('EditProductController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('Api', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Apis = list;
        });
    });
    entityService.getIdNameList('Product', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Products = list;
        });
    });
    entityService.getIdNameList('ProductType', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.ProductTypes = list;
        });
    });
    entityService.getIdNameList('Supplier', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Suppliers = list;
        });
    });
    entityService.getIdNameList('LifeCycle', 200, 0, function (list) {
        $scope.$apply(function () {
            $scope.LifeCycles = list;
        });
    });


    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewProductController', function ($scope, $routeParams, entityService) {

    entityService.getList('ProductPrice', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.prices = res.list;
        });
    }, "ProductId = " + $routeParams.Id);
    entityService.getEnumList('ProductPriceTypes', function (res) {
        $scope.$apply(function () {
            $scope.priceTypes = res;
        });
    });


    entityService.get('Product', $routeParams.Id, function (entity) {
        $scope.$apply(function () {
            $scope.entity = entity;

            entityService.getList('PropertyValue', 20, 0, function (res) {
                $scope.$apply(function () {
                    $scope.props = res.list;
                    $scope.props.each(function (a) { a.PropertyValue = a.PropertyValue || a.DefaultValue; });
                });
            }, "EntityName = Product AND EntityId = " + $scope.entity.Id);

        });
    });

    $scope.min = function (arr) {
        return Math.min.apply(Math, arr.map(function (e) { return e.OrderNo; }));
    }

    $scope.tab = 'props';
    var oldVal = null;
    var oldProp = null;

    $scope.editProp = function (pt, a) {
        if (oldProp != null)
            oldProp.PropertyValue = oldVal;
        oldVal = a.PropertyValue;
        oldProp = a;
        pt.currProp = a;
    };
    $scope.cancelEditProp = function (pt) {
        pt.currProp.PropertyValue = oldVal;
        pt.currProp = null;
        oldProp = null;
    };
    $scope.saveProp = function (pt) {
        entityService.save('PropertyValue', pt.currProp, function () {
            $scope.$apply(function () {
                pt.currProp = null;
                oldProp = null;
            });
        });
    };

    $scope.editPrice = function (a) {
        $scope.currPrice = a;
        $scope.currPrice.Price /= 100;
        $scope.currPrice.PurchasePrice /= 100;
        $scope.currPrice.DiscountPrice /= 100;
    };
    $scope.newPrice = function () {
        $scope.currPrice = { ProductId: $routeParams.Id, Price: 0, PurchasePrice: 0, DiscountPrice: 0 };
    };
    $scope.deletePrice = function (a) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("ProductPrice", a, function () {
                $scope.$apply(function () {
                    a.IsDeleted = true;
                });
            });
    };
    $scope.cancelEditPrice = function () {
        $scope.currPrice.Price *= 100;
        $scope.currPrice.PurchasePrice *= 100;
        $scope.currPrice.DiscountPrice *= 100;
        $scope.currPrice = null;
    };
    $scope.savePrice = function () {
        var isNew = !$scope.currPrice.Id;
        $scope.currPrice.Price *= 100;
        $scope.currPrice.PurchasePrice *= 100;
        $scope.currPrice.DiscountPrice *= 100;
        entityService.save("ProductPrice", $scope.currPrice, function (ca) {
            $scope.$apply(function () {
                if (isNew)
                    $scope.prices.push(ca);
                else
                    $scope.prices[$scope.prices.indexOf($scope.currPrice)] = ca;
                $scope.currPrice = null;
            });
        });
    };
});

app.controller('EditSupplierController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('Api', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Apis = list;
        });
    });
    entityService.getIdNameList('LifeCycle', 200, 0, function (list) {
        $scope.$apply(function () {
            $scope.LifeCycles = list;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});

app.controller('EditRegistryController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('RegistryBackend', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.RegistryBackends = list;
        });
    });

    $scope.entityName = 'Registry';
    $scope.entityId = $routeParams.Id;

    viewDetailEditController($scope, $routeParams, entityService);
});

app.controller('EditApiClientController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('Api', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Apis = list;
        });
    });
    entityService.getIdNameList('Client', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Clients = list;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});

app.controller('ListRoleController', function ($scope, $routeParams, entityService) {

    entityService.getEnumList('Rights', function (list) {
        $scope.$apply(function () {
            $scope.rightOptions = list;
        });
    });

    defaultListController($scope, $routeParams, entityService);

    $scope.readRights = function (role) {
        if (role.rights)
            role.rights = null;
        else
            entityService.getList('RoleRight', 20000, 0, function (res) {
                $scope.$apply(function () {
                    role.rights = res.list;
                });
            }, "RoleId = " + role.Id);
    };

    $scope.rename = function (role) {
        $scope.renameRole = role;
    };
    $scope.renameCancel = function () {
        $scope.renameRole = null;
    };
    $scope.renameSave = function () {
        entityService.save('Role', $scope.renameRole, function () {
            $scope.$apply(function () {
                $scope.renameRole = null;
            });
        });
    };

    $scope.editRight = function (role, a) {
        role.currRight = a;
    };
    $scope.newRight = function (role) {
        role.currRight = { RoleId: role.Id };
    };
    $scope.deleteRight = function (role, rr) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("RoleRight", rr, function () {
                $scope.$apply(function () {
                    rr.IsDeleted = true;
                    role.RightCount = role.rights.length;
                });
            });
    };
    $scope.cancelEditRight = function (role) {
        role.currRight = null;
    };
    $scope.saveRight = function (role) {
        var isNew = !role.currRight.Id;
        if (!role.rights) role.rights = [];
        entityService.save("RoleRight", role.currRight, function (rr) {
            $scope.$apply(function () {
                rr.Right = $scope.rightOptions.find(function (r) { return r.Id == rr.Right }).Name;
                if (isNew)
                    role.rights.push(rr);
                else
                    role.rights[role.rights.indexOf(role.currRight)] = rr;
                role.currRight = null;
                role.RightCount = role.rights.length;
            });
        });
    };
});

app.controller('EditNewsletterDefinitionController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('Api', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Apis = list;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});

app.controller('ListOrderController', function ($scope, $routeParams, entityService) {

    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedState) $scope.where += ($scope.where ? ' AND ' : '') + 'State = ' + $scope.selectedState;

        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 1;

    entityService.getEnumList('OrderStates', function (list) {
        $scope.$apply(function () {
            $scope.StateList = list;
            $scope.tryFirstSearch();
        });
    });


    defaultListController($scope, $routeParams, entityService);

    if ($routeParams.where && $routeParams.where.indexOf('MemberId') == 0) {
        var memberId = $routeParams.where.split(' = ')[1];
        entityService.get('Member', memberId, function (entity) {
            $scope.$apply(function () {
                $scope.member = entity;
            });
        });
    }
});
app.controller('ViewOrderController', function ($scope, $routeParams, entityService) {

    entityService.get($routeParams.entityName, $routeParams.Id, function (entity) {
        $scope.$apply(function () {
            $scope.entity = entity;

            entityService.get('MemberAddress', entity.MemberAddressId, function (ma) {
                $scope.$apply(function () {
                    $scope.address = ma;
                });
            });

            entityService.getList('OrderItem', 200, 0, function (res) {
                $scope.$apply(function () {
                    $scope.entity.items = res.list;

                    var satirlar = $.map($scope.entity.items, function (i) { return "'" + i.Id + "'"; }).join();

                    entityService.getList('Job', 500, 0, function (res) {
                        $scope.$apply(function () {
                            $scope.entity.jobs = res.list;
                        });
                    }, "RelatedEntityName = OrderItem AND RelatedEntityId IN " + satirlar, 'InsertDate');
                });
            }, "OrderId = " + $routeParams.Id + ' AND ParentOrderItemId ISNULL', 'OrderNo');
        });
    });

    $scope.expand = function (i) {
        entityService.getList('OrderItem', 200, 0, function (res) {
            $scope.$apply(function () {
                i.items = res.list;
                i.expanded = true;
            });
        }, "OrderId = " + $routeParams.Id + ' AND ParentOrderItemId = ' + i.Id, 'OrderNo');
    };
    $scope.collapse = function (i) {
        i.expanded = false;
        i.items = null;
    };

    $scope.expandJD = function (i) {
        entityService.getList('JobData', 200, 0, function (res) {
            $scope.$apply(function () {
                i.items = res.list;
                i.expanded = true;
            });
        }, "JobId = " + i.Id);
    };
    $scope.collapseJD = function (i) {
        i.expanded = false;
        i.items = null;
    };
});

app.controller('EditCouponController', function ($scope, $routeParams, entityService) {

    entityService.getEnumList('CouponTypes', function (res) {
        $scope.$apply(function () {
            $scope.EnumCouponTypes = res;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewCouponController', function ($scope, $routeParams, entityService) {

    $scope.tab = 'products';

    $scope.addProduct = function () {
        entityService.save("CouponProduct", { ProductId: $scope.selectedProduct, CouponId: $scope.entity.Id }, function (ca) {
            $scope.$apply(function () {
                var cs = findViewDetailScope($scope, 'CouponProduct');
                cs.getPage(cs.currPage);
            });
        });
    };

    entityService.getIdNameList('Product', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Products = list;
        });
    });


    defaultViewController($scope, $routeParams, entityService);
});

app.controller('EditResellerTypeController', function ($scope, $routeParams, entityService) {

    entityService.getEnumList('ListInPartnerNetwork', function (res) {
        $scope.$apply(function () {
            $scope.EnumListInPartnerNetwork = res;
        });
    });

    entityService.getEnumList('SupportGroup', function (res) {
        $scope.$apply(function () {
            $scope.EnumSupportGroup = res;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});

app.controller('EditMdfController', function ($scope, $routeParams, entityService) {

    entityService.getIdNameList('Country', 2000, 0, function (list) {
        $scope.$apply(function () {
            $scope.ListCountry = list;
        });
    });
    entityService.getIdNameList('ResellerType', 2000, 0, function (list) {
        $scope.$apply(function () {
            $scope.ListResellerType = list;
        });
    });


    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewMdfController', function ($scope, $routeParams, entityService) {

    $scope.tab = 'resellers';

    $scope.addProduct = function () {
        entityService.save("MdfProduct", { ProductId: $scope.selectedProduct, MdfId: $scope.entity.Id }, function (ca) {
            $scope.$apply(function () {
                var cs = findViewDetailScope($scope, 'MdfProduct');
                cs.getPage(cs.currPage);
            });
        });
    };

    entityService.getIdNameList('Product', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Products = list;
        });
    });

    defaultViewController($scope, $routeParams, entityService);
    setLocalization($scope, $routeParams, entityService)
});

app.controller('ListResellerController', function ($scope, $routeParams, entityService) {
    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedResellerTypeName) $scope.where += ($scope.where ? ' AND ' : '') + 'ResellerTypeName = ' + $scope.selectedResellerTypeName;

        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 1;

    entityService.getIdNameList('ResellerType', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.ResellerTypes = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);
});
app.controller('EditResellerController', function ($scope, $routeParams, entityService) {
    entityService.getIdNameList('ResellerType', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.ResellerTypes = list;
        });
    });
    entityService.getEnumList('ListInPartnerNetwork', function (res) {
        $scope.$apply(function () {
            $scope.EnumListInPartnerNetwork = res;
        });
    });
    entityService.getEnumList('SupportGroup', function (res) {
        $scope.$apply(function () {
            $scope.EnumSupportGroup = res;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewResellerController', function ($scope, $routeParams, entityService) {

    $scope.tab = 'mdfs';

    defaultViewController($scope, $routeParams, entityService);
});

app.controller('ViewFeedbackController', function ($scope, $routeParams, entityService) {

    $scope.sendFeedbackReply = function (e) {

        var replyMessage = $('#txtReplyMessage').val();
        entityService.save("Feedback", { ReplyMessage: replyMessage, Id: e.Id }, function () {
            location.href = '/Staff/Handlers/DoCommand.ashx?method=sendFeedbackReply&id=' + e.Id;
        });
    };

    $scope.changeState = function (e, state) {
        entityService.getList("Job", 1, 0, function (res) {
            var j = res.list[0];
            j.State = state;
            entityService.save('Job', j, function (res2) {
                $scope.$apply(function () {
                    e.State = res2.State;
                });
            });
        }, "RelatedEntityName = Feedback AND RelatedEntityId = " + e.Id);
    };

    defaultViewController($scope, $routeParams, entityService);

});

app.controller('ViewCrmActivityController', function ($scope, $routeParams, entityService) {
    $scope.getList = function () {
        entityService.getList('CrmActivityMessage', 20, 0, function (res) {
            $scope.$apply(function () {
                $scope.tickets = res.list;
            });
        }, "CrmActivityId = " + $routeParams.Id, 'InsertDate desc');
    };
    $scope.getList();

    $scope.addReply = function () {

        var reply = $('#txtreply').val();
        entityService.save("CrmActivityMessage", { Message: reply, CrmActivityId: $scope.entity.Id }, function (cam) {
            $scope.$apply(function () {
                $scope.getList();
                $('#txtreply').val('');
            });
        });
    };

    $scope.changeState = function (e, state) {
        entityService.getList("Job", 1, 0, function (res) {
            var j = res.list[0];
            j.State = state;
            entityService.save('Job', j, function (res2) {
                $scope.$apply(function () {
                    e.State = res2.State;
                });
            });
        }, "RelatedEntityName = CrmActivity AND RelatedEntityId = " + e.Id);
    };

    $scope.tab = 'tickets';

    defaultViewController($scope, $routeParams, entityService);
});

app.controller('ViewDetailListMDFResellerController', function ($scope, $routeParams, entityService) {
    viewDetailListController($scope, $routeParams, entityService);

    $scope.changeState = function (e, state) {
        e.State = state;
        entityService.save('MdfReseller', e, function (res) {
            $scope.$apply(function () {
                e.State = res.State;
            });
        });
    };
});

function findViewDetailScope(scope, entityName) {
    for (var cs = scope.$$childHead; cs; cs = cs.$$nextSibling) {
        if (cs.entityName == entityName)
            return cs;
    }
}

app.controller('APIDemoController', function ($scope, $routeParams, entityService) {
});


app.controller('ListCCProfileController', function ($scope, $routeParams, entityService) {

    defaultListController($scope, $routeParams, entityService);
});
app.controller('EditCCProfileController', function ($scope, $routeParams, entityService) {

    entityService.getEnumList('ProfileType', function (res) {
        $scope.$apply(function () {
            $scope.EnumProfileTypes = res;
        });
    });
    entityService.getEnumList('Priority', function (res) {
        $scope.$apply(function () {
            $scope.EnumPrioritys = res;
        });
    });

    entityService.getIdNameList('Client', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Clients = list;
        });
    });

    entityService.getIdNameList('CCEmailSocket', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.EmailSockets = list;
        });
    });

    entityService.getIdNameList('CCSmsSocket', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.SmsSockets = list;
        });
    });



    defaultEditController($scope, $routeParams, entityService);

});
app.controller('ViewCCProfileController', function ($scope, $routeParams, entityService) {

    defaultViewController($scope, $routeParams, entityService);
});
app.controller('ListCCEmailSocketController', function ($scope, $routeParams, entityService) {


    $scope.search = function () {
        $scope.where = '';
        if ($scope.selectedProfile) $scope.where += ($scope.where ? ' AND ' : '') + ' Id IN (select CCEmailSocketId from CCProfile where Id= \'' + $scope.selectedProfile + '\' ) ';
        $scope.getPage(0);
    };

    $scope.tryFirstSearchCounter = 1;


    entityService.getIdNameList('CCProfile', 200, 0, function (list) {
        $scope.$apply(function () {
            $scope.Profiles = list;
            $scope.tryFirstSearch();
        });
    }, "ProfileType = Email ");


    defaultListController($scope, $routeParams, entityService);

    if ($routeParams.where && $routeParams.where.indexOf('ProfileId') == 0) {
        var profileId = $routeParams.where.split(' = ')[1];
        $scope.selectedProfile = profileId;
    }

});
app.controller('EditCCEmailSocketController', function ($scope, $routeParams, entityService) {


    entityService.getEnumList('DeliveryFormat', function (res) {
        $scope.$apply(function () {
            $scope.EnumDeliveryFormats = res;
        });
    });

    entityService.getEnumList('DeliveryMethod', function (res) {
        $scope.$apply(function () {
            $scope.EnumDeliveryMethods = res;
        });
    });



    defaultEditController($scope, $routeParams, entityService);

});
app.controller('ListCCSmsSocketController', function ($scope, $routeParams, entityService) {

    $scope.search = function () {
        $scope.where = '';

        if ($scope.selectedProfile) $scope.where += ($scope.where ? ' AND ' : '') + ' Id IN (select CCSmsSocketId from CCProfile where Id= \'' + $scope.selectedProfile + '\' ) ';

        $scope.getPage(0);
    };


    $scope.tryFirstSearchCounter = 1;

    entityService.getIdNameList('CCProfile', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Profiles = list;
            $scope.tryFirstSearch();
        });
    }, "ProfileType = Sms ");


    defaultListController($scope, $routeParams, entityService);

    if ($routeParams.where && $routeParams.where.indexOf('ProfileId') == 0) {
        var profileId = $routeParams.where.split(' = ')[1];
        $scope.selectedProfile = profileId;
    }

});
app.controller('EditCCSmsSocketController', function ($scope, $routeParams, entityService) {


    defaultEditController($scope, $routeParams, entityService);

});
app.controller('ListCCMessageGroupController', function ($scope, $routeParams, entityService) {

    $scope.search = function () {
        $scope.where = '';

        if ($scope.selectedProfile) $scope.where += ($scope.where ? ' AND ' : '') + 'CCProfileId = ' + $scope.selectedProfile;

        $scope.getPage(0);

    };

    $scope.tryFirstSearchCounter = 1;


    entityService.getIdNameList('CCProfile', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.Profiles = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);

    if ($routeParams.where && $routeParams.where.indexOf('ProfileId') == 0) {
        var profileId = $routeParams.where.split(' = ')[1];
        $scope.selectedProfile = profileId;
    }
});
app.controller('EditCCMessageGroupController', function ($scope, $routeParams, entityService) {


    entityService.getIdNameList('CCProfile', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.CCProfiles = list;
        });
    });


    defaultEditController($scope, $routeParams, entityService);

});
app.controller('ListCCMessageTemplateController', function ($scope, $routeParams, entityService) {


    $scope.search = function () {
        $scope.where = '';

        if ($scope.selectedMsgGroup) $scope.where += ($scope.where ? ' AND ' : '') + 'CCMessageGroupId = ' + $scope.selectedMsgGroup;

        $scope.getPage(0);

    };

    $scope.tryFirstSearchCounter = 1;


    entityService.getIdNameList('CCMessageGroup', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.MsgGroups = list;
            $scope.tryFirstSearch();
        });
    });

    defaultListController($scope, $routeParams, entityService);

    if ($routeParams.where && $routeParams.where.indexOf('MsgGroupId') == 0) {
        var msgGroupId = $routeParams.where.split(' = ')[1];
        $scope.selectedMsgGroup = msgGroupId;
    }

});
app.controller('EditCCMessageTemplateController', function ($scope, $routeParams, entityService) {


    entityService.getIdNameList('CCMessageGroup', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.MsgGroups = list;
        });
    });

    defaultEditController($scope, $routeParams, entityService);

});
app.controller('ViewCCMessageTemplateController', function ($scope, $routeParams, entityService) {

    defaultViewController($scope, $routeParams, entityService);
});


app.controller('EditMemberDomainController', function ($scope, $routeParams, entityService) {

    entityService.getEnumList('DomainRenewalModes', function (res) {
        $scope.$apply(function () {
            $scope.EnumDomainRenewalModes = res;
        });
    });
    entityService.getEnumList('DomainTransferModes', function (res) {
        $scope.$apply(function () {
            $scope.EnumDomainTransferModes = res;
        });
    });
    entityService.getEnumList('RegistryStates', function (res) {
        $scope.$apply(function () {
            $scope.EnumRegistryStates = res;
        });
    });
    entityService.getEnumList('RGPStates', function (res) {
        $scope.$apply(function () {
            $scope.EnumRGPStates = res;
        });
    });
    entityService.getEnumList('PrivacyProtectionOptions', function (res) {
        $scope.$apply(function () {
            $scope.EnumPrivacyProtectionOptions = res;
        });
    });
    entityService.getEnumList('OperationalStates', function (res) {
        $scope.$apply(function () {
            $scope.EnumOperationalStates = res;
        });
    });

    defaultEditController($scope, $routeParams, entityService);
});
app.controller('ViewMemberDomainController', function ($scope, $routeParams, entityService) {


    $scope.tab = 'contact';

    entityService.getList('DomainContact', 20, 0, function (res) {
        $scope.$apply(function () {
            $scope.addresses = res.list;
        });
    }, "MemberDomainId = " + $routeParams.Id);



    entityService.getEnumList('ContactTypes', function (res) {
        $scope.$apply(function () {
            $scope.EnumContactTypes = res;
        });
    });



    entityService.getIdNameList('Country', 1000, 0, function (list) {
        $scope.$apply(function () {
            $scope.countries = list;
        });
    });

    $scope.getCities = function () {
        var filter = null;
        if ($scope.currAddr.Country && $scope.currAddr.Country)
            filter = "CountryId = " + $scope.currAddr.Country;

        entityService.getIdNameList('City', 1000, 0, function (list) {
            $scope.$apply(function () {
                $scope.cities = list;
            });
        }, filter);
    };


    $scope.editAddress = function (a) {
        $scope.currAddr = a;
        if (a.Country) $scope.getCities();
    };
    $scope.newAddress = function () {
        $scope.currAddr = { MemberDomainId: $routeParams.Id, };
    };
    $scope.deleteAddress = function (a) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete("DomainContact", a, function () {
                $scope.$apply(function () {
                    a.IsDeleted = true;
                });
            });
    };
    $scope.cancelEditAddress = function () {
        $scope.currAddr = null;
    };
    $scope.saveAddress = function () {
        var isNew = !$scope.currAddr.Id;
        entityService.save("DomainContact", $scope.currAddr, function (ca) {
            $scope.$apply(function () {
                if (isNew)
                    $scope.addresses.push(ca);
                else
                    $scope.addresses[$scope.addresses.indexOf($scope.currAddr)] = ca;
                $scope.currAddr = null;
            });
        });
    };



    defaultViewController($scope, $routeParams, entityService);
});


app.controller('ListDomainContactController', function ($scope, $routeParams, entityService) {

    $scope.search = function () {
        $scope.where = '';

        if ($scope.txtDomainName) $scope.where += ($scope.where ? ' AND ' : '') + ' MemberDomainId IN (select Id from MemberDomain where DomainName LIKE \'%' + $scope.txtDomainName + '%\' ) ';

        $scope.getPage(0);
    };

    defaultListController($scope, $routeParams, entityService);

});

app.controller('ViewLifeCycleController', function ($scope, $routeParams, entityService) {

    $scope.getFunc = function () {
        $scope.readPhases();
    };

    entityService.getIdNameList('CCMessageTemplate', 20, 0, function (list) {
        $scope.$apply(function () {
            $scope.MessageTemplates = list;
        });
    });


    $scope.colors = ['rgb(245, 230, 210)', 'rgb(199, 252, 199)', 'rgb(199, 252, 199)', 'rgb(124, 240, 255)', 'rgb(255, 209, 124)', 'rgb(255, 185, 197)', 'rgb(255, 254, 174)'];

    $scope.readPhases = function () {
        entityService.getList('LifeCyclePhase', 2000, 0, function (res) {
            $scope.$apply(function () {
                $scope.phases = res.list || [];

                $scope.totalDays = 0;
                $scope.totalWidth = 0;
                for (var i = 0; i < $scope.phases.length; i++) {
                    var p = $scope.phases[i];
                    p.ui = {};
                    $scope.totalDays += p.Days;
                    p.ui.color = $scope.colors[i % $scope.colors.length];
                    p.ui.width = Math.log(p.Days + 1);
                    $scope.totalWidth += p.ui.width;
                }
            });

            entityService.getList('LifeCycleJob', 2000, 0, function (res) {
                $scope.$apply(function () {
                    $scope.jobs = res.list || [];
                    for (var i = 0; i < $scope.jobs.length; i++) {
                        var j = $scope.jobs[i];
                        j.ui = {};
                        j.ui.left = $scope.calculateLogorithmicPosition(j.RunAtDay);
                        j.ui.top = 30 + 50 * (i % 5);
                    }
                });
            }, "LifeCycleId = " + $scope.entity.Id + " AND IsDeleted = 0", 'RunAtDay');

        }, "LifeCycleId = " + $scope.entity.Id + " AND IsDeleted = 0", 'OrderNo');

    };

    $scope.calculateLogorithmicPosition = function (x) {
        var res = 0;
        for (var i = 0; i < $scope.phases.length; i++) {
            var p = $scope.phases[i];
            if (x > p.Days) {
                res += Math.log(p.Days + 1);
                x -= p.Days;
            } else {
                res += Math.log(p.Days + 1) * x / p.Days;
                break;
            }
        }
        return res;
    };

    $scope.addPhase = function (p) {
        $scope.currPhase = {LifeCycleId: $scope.entity.Id};
    };
    $scope.editPhase = function (p) {
        $scope.currPhase = p;
    };
    $scope.savePhase = function () {
        entityService.save('LifeCyclePhase', $scope.currPhase, function () {
            $scope.$apply(function () {
                $scope.currPhase = null;
                $scope.readPhases();
            });
        });
    };
    $scope.cancelEditPhase = function () {
        $scope.currPhase = null;
    };
    $scope.deletePhase = function (p) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete('LifeCyclePhase', p, function () {
                $scope.$apply(function () {
                    $scope.readPhases();
                });
            });
    };

    entityService.getEnumList('JobCommands', function (res) {
        $scope.$apply(function () {
            $scope.EnumJobCommands = res;
        });
    });
    entityService.getEnumList('JobExecuters', function (res) {
        $scope.$apply(function () {
            $scope.EnumJobExecuters = res;
        });
    });

    $scope.addJob = function (p) {
        $scope.currJob = { LifeCycleId: $scope.entity.Id };
    };
    $scope.editJob = function (j) {
        $scope.currJob = j;
    };
    $scope.saveJob = function () {
        if ($scope.currJob.Command == "CCSendMessage") {
            $scope.currJob.RelatedEntityName = "CCMessageTemplate";
        }
        entityService.save('LifeCycleJob', $scope.currJob, function () {
            $scope.$apply(function () {
                $scope.currJob = null;
                $scope.readPhases();
            });
        });
    };
    $scope.cancelEditJob = function () {
        $scope.currJob = null;
    };
    $scope.deleteJob = function (j) {
        if (confirm('It\'s gonna be deleted!'))
            entityService.delete('LifeCycleJob', j, function () {
                $scope.$apply(function () {
                    $scope.readPhases();
                });
            });
    };

    defaultViewController($scope, $routeParams, entityService);
});



function setCriteriaValue(where, field, value) {
    if (!where) where = '';
    if (value != null) {
        if (where.indexOf(field) == -1) {
            return where + ((where ? ' AND ' : '') + field + ' = ' + value);
        } else {
            var parts = where.split(' AND ');
            for (var i = 0; i < parts.length; i++) {
                var keyVal = parts[i].split(' = ');
                if (keyVal[0] == field)
                    parts[i] = keyVal[0] + ' = ' + value;
            }
            return parts.join(' AND ');
        }
    } else {
        if (where.indexOf(field) == -1) {
            return where;
        } else {
            var parts = where.split(' AND ');
            for (var i = 0; i < parts.length; i++) {
                var keyVal = parts[i].split(' = ');
                if (keyVal[0] == field) {
                    parts.splice(i);
                }
            }
            return parts.join(' AND ');
        }
    }
}

function setLocalization($scope, $routeParams, entityService) {
    entityService.getList('LanguageValue', 100, 0, function (res) {
        $scope.$apply(function () {
            $scope.localization = {};
            for (var i = 0; i < res.list.length; i++) {
                var l = res.list[i];
                if (!$scope.localization[l.FieldName]) $scope.localization[l.FieldName] = [];
                $scope.localization[l.FieldName].push(l);
            }
        });
    }, 'EntityName = ' + $scope.entityName + ' AND EntityId = ' + $routeParams.Id, 'FieldName');

    $scope.localize = function (fieldName) {
        location.href = '#/List/ViewEntityLocaleAll/EntityName = ' + $scope.entityName + ' AND FieldName = ' + fieldName + ' AND EntityId = ' + $scope.entity.Id;
    };
}
