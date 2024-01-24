/**Инициализировать элементы страницы */
function InitElements() {
    //Инициализация таблиц DataTable
    $('.js-data-table').DataTable();

    //Инициализация редакторов summernote
    $('.js-summernote').summernote();

    //Инициализация дроп даун листов Select2
    $('.js-select2').select2({ theme: 'bootstrap4' });

    //Инициализация кастомных полей выбора файла
    bsCustomFileInput.init();
}


/**
 * Получить частичное представление
 * @param {any} URL URL
 * @param {any} TargetId Id элемента назначения, куда нужно поместить частичное представление
 */
function GetPartialAsync(URL, TargetId) {
    fetch(URL)
        .then((response) => {
            return response.text();
        })
        .then((result) => {
            document.getElementById(TargetId).innerHTML = result;
            InitElements();
        });
}

$(function () {
    InitElements();
});