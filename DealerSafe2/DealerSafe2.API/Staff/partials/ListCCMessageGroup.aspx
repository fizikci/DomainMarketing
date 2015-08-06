<list-header title="Message Group"></list-header>


<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select no-empty-option="1" horizontal="1" label="Profile" name="CCProfileId" model="selectedProfile" options="i.Id as i.Name for i in Profiles"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<div style="clear: both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Name" field="Name"></th>
            <th column-header="Profile" field="CCProfileName"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td>{{entity.Name}}</td>
            <td>{{entity.CCProfileName}}</td>
            <td operations>
                <a class="dtBtn red" href="#/List/CCMessageTemplate/MsgGroupId = {{entity.Id}}"><i class="icon-search bigger-130" title="List Message Template"></i></a>
            </td>
        </tr>
    </tbody>
</table>



<list-footer></list-footer>


