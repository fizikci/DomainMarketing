<list-header title="Members"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
    <input-text horizontal="1" label="Subject" name="Subject" model="subject"></input-text> 
    <input type="button" value="Filtrele" ng-click="search()" />
</form>

<pagination></pagination>


<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Subject" field="Subject"></th>
            <th column-header="Message" field="Body"></th>
            <th column-header="Date" field="InsertDate"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td>{{entity.Subject}}</td>
            <td>{{entity.Body}}</td>
            <td>{{entity.InsertDate | date:'yyyy.MM.dd'}}</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>
