<list-header title="Products"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="Type" name="ProductTypeId" model="selectedProductType" options="i.Id as i.Name for i in ProductTypes"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Type" field="ProductType"></th>
            <th column-header="Supplier - Priority" field="Supplier"></th>
            <th column-header="Featured" field="IsFeatured"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.ProductTypeName}}</td>
            <td>{{entity.SupplierName + ' - ' + entity.SupplierPriority}}</td>
            <td><i ng-if="entity.IsFeatured" class="icon-ok green bigger-110"></i></td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>