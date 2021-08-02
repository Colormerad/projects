var ds = new DataService();

function formatRow(result) {
    <table class="SearchResults" id="StudentList">
        <tbody>
            <tr>${result.StudentName}</tr>
        </tbody>
    </table>
}

function TeacherField(Teacher) {
    <div class="TeacherField" id="TeacherField">
        ${Teacher.Teacher}
    </div>
}

function alertError(msg) {
    alert(msg);
}

function populateStudents(data) {
    let TeacherField = $('#Teacher');
    TeacherField.empty();
    $(TeacherField).append(TeacherField(Teacher));

    let StudentDropDown = $('#Student');
    StudentDropDown.empty();

    for (let i = 0; i < data.length; i++) {
        const result = data[i];
        $(StudentDropDown).append(formatRow(result));
    }

}

function onChangeClass() {
    var searchquery = {
        Id: $("#Class_Id").val()
    };
    ds.searchClasses(searchquery, populateStudents, alertError);
}

$(document).ready(function () {
    //$(document).on("change", "#ClassList", onChangeClass);
    //onChangeClass(this);
});
