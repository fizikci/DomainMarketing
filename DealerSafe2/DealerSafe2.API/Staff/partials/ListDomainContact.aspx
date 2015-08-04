<list-header title="Domain Contact"></list-header>



<form id="form" class="form-inline" role="form" autocomplete="off">
    <label for="DomainName" class=" control-label no-padding-right">Domain Name</label>
    <div>
        <input type="text" ng-model="txtDomainName" name="Domain Name" name="DomainName" />
        <input type="button" value="Filtrele" ng-click="search()" />
    </div>
</form>

<div style="clear: both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Email" field="Email"></th>
            <th column-header="Owner" field="MemberName"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name || entity.Organization}}</td>
            <td>{{entity.Email}}</td>
            <td><a href="#/View/Member/{{entity.MemberId}}">{{entity.MemberName}}</a></td>
            <td operations delete="off"></td>
        </tr>
    </tbody>
</table>



<list-footer no-add-new="1"></list-footer>


