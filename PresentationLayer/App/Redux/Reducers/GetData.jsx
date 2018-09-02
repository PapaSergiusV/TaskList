export default class GetData {
    static getTasksNameOfList = (id) => {
        var xhr = new XMLHttpRequest();
        var body = 'id=' + encodeURIComponent(id);
        xhr.open("POST", "/Tasks/GetTasksNameOfList", false);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.onreadystatechange = (function () {
            var list = { key: "", value: [] };
            if (xhr.readyState == 4 && xhr.status == 200) {
                list = JSON.parse(xhr.responseText);
                console.log(list);
                return list;
            }
            else return list;
        });

        xhr.send(body);
    }
}