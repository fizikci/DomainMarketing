<list-header title="Profile"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
</form>

<div style="clear: both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Profile Type" field="ProfileType"></th>
            <th column-header="Priority" field="Priority"></th>
            <th column-header="Client" field="ClientName"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td>{{entity.ProfileType}}</td>
            <td>{{entity.Priority}}</td>
            <td>{{entity.ClientName}}</td>
            <td operations>
                <a class="dtBtn red" href="#/List/CCEmailSocket/ProfileId = {{entity.Id}}"><i class="icon-search bigger-130" title="List E-Mail Socket"></i></a>     
                <a class="dtBtn blue" href="#/List/CCSmsSocket/ProfileId = {{entity.Id}}"><i class="icon-search bigger-130" title="List Sms Socket"></i></a>
                <a class="dtBtn green" href="#/List/CCMessageGroup/ProfileId = {{entity.Id}}"><i class="icon-search bigger-130" title="List Message Group"></i></a>
            </td>
        </tr>
    </tbody>
</table>



<list-footer></list-footer>


