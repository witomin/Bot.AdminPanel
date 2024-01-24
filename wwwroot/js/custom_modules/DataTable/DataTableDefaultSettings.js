// Настройки поумолчанию для DataTable
$.extend($.fn.dataTable.defaults, {
    destroy: true,
    info: true,
    ordering: true,
    searching: false,
    "lengthMenu": [[10, 20, 50, 100, 150, 200, -1], ['10 строк', '20 строк', '50 строк', '100 строк', '150 строк', '200 строк', 'Все строки']],
    "pageLength": 10,
    "language": {
        "lengthMenu": "Показывать _MENU_ на страницу",
        "zeroRecords": "Извините, ничего не найдено",
        "loadingRecords": "Загрузка...",
        "processing": "Обработка...",
        "search": "Поиск в найденном:",
        "info": "Страница _PAGE_ из _PAGES_",
        "infoEmpty": "Нет доступных записей",
        "sEmptyTable": "Нет доступных записей",
        "infoFiltered": "(Всего найдено _MAX_)",
        "decimal": ",",
        "thousands": " ",
        "paginate": {
            "first": "Первая",
            "last": "Последняя",
            "next": "Следующая",
            "previous": "Предыдущая"
        },
        "select": {
            "rows": {
                "_": "Выбрано записей: %d",
                "0": "Кликните по записи для выбора",
                "1": "Выбрана одна запись"
            }
        },
    },
    stateSave: true,
    stateDuration: 60 * 60 * 24 * 7
});