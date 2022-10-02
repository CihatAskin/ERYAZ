let $search = document.getElementById('search');
let $reset = document.getElementById('reset');
let $title = document.getElementById('t');
let $year = document.getElementById('y');
let $kind = document.getElementById('kind');
let $error = document.getElementById('error');

var $body = document.getElementById('body');

$search.addEventListener('click', () => {

    doGet(`/Film/Search?title=${$title.value}&year=${$year.value}&kind=${kind.value}`, (req) => {

        var response = JSON.parse(req.responseText);
        console.log(response);
        console.log(req);
        if (response.messages.length === 0) {
            fillTable(response.item.search)
            $error.classList.add('d-none');
        } else {
            $error.classList.remove('d-none');
            $error.innerText = response.messages;
        }
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });
})

let fillTable = (items) => {
    $body.innerHTML = '';
    for (var i = 0; i < items.length; i++) {

        let item = items[i];
        console.log(item);
        let row = createElement('tr');
        row.appendChild(createElement('td', '', item.title))
        row.appendChild(createElement('td', '', item.year))
        row.appendChild(createElement('td', '', item.type))


        var td = row.appendChild(createElement('td',))
        td.appendChild(createElement('img', { src: item.poster, "loading":"lazy" }));
        body.appendChild(row);
    }

}