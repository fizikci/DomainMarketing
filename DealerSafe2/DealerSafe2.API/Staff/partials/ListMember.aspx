<list-header title="Members"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-select horizontal="1" label="Type" name="MemberType" model="selectedMemberType" options="i.Id as i.Name for i in MemberTypeList"></input-select> 
    <input-select horizontal="1" label="State" name="State" model="selectedState" options="i.Id as i.Name for i in StateList"></input-select>
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<pagination></pagination>


<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Email" field="Email"></th>
            <th column-header="Name" field="FullName"></th>
            <th column-header="Type" field="MemberType"></th>
            <th column-header="Date" field="InsertDate"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>
                {{entity.Email}} 
                <i ng-if="entity.State=='Confirmed'" class="icon-ok bigger-130 green"></i>
                <img ng-if="entity.Medal" ng-src="/Assets/images/icons/medal_{{entity.Medal}}.png" title="{{entity.Medal}} Partnership" />
            </td>
            <td>{{entity.FullName}}</td>
            <td>{{entity.MemberType}}</td>
            <td>{{entity.InsertDate | date:'yyyy.MM.dd'}}</td>
            <td operations>
                <a class="dtBtn red" href="#/List/Order/MemberId = {{entity.Id}}"><i class="icon-shopping-cart bigger-130" title="Orders"></i></a>
                <a class="dtBtn green" ng-click="login(entity)"><i class="icon-user bigger-130" title="Login"></i></a>
            </td>
        </tr>
    </tbody>
</table>

<list-footer no-add-new="true"></list-footer>
