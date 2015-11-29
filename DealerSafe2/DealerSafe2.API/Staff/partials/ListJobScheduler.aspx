<list-header title="Job Scheduler"></list-header>

<form id="form" class="form-inline" role="form" autocomplete="off">
</form>

<div style="clear: both"></div>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
             <th column-header="Name" field="Name"></th>
            <th column-header="Command" field="Command"></th>
            <th column-header="Last Execution" field="LastExecution"></th>
            <th column-header="Seconds" field="RecurEverySeconds"></th>

            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-view>{{entity.Name}}</td>
            <td link-to-view>{{entity.Command}}</td>
            <td>{{entity.LastExecution}}</td>
            <td>{{entity.RecurEverySeconds}}</td>
            <td operations>

            </td>
        </tr>
    </tbody>
</table>



<list-footer></list-footer>


