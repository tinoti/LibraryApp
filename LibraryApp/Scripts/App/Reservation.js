$(document).ready(function () {

    var bookList = [];
    var bookIds = [];

    //If the app is coming from the Book view, split the query and put the values in bookIds list
    if (bookList.length === 0) {
        if (window.location.search.split('?').length > 1) {
            var params = window.location.search.split('?')[1].split('&');
            for (var i = 0; i < params.length; i++) {
                var value = decodeURIComponent(params[i].split('=')[1]);
                bookIds.push(parseInt(value));
            }
        }
    }
   

    var MAXINPUT = 4;

    var book = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/books?query=%QUERY',
            wildcard: '%QUERY',
            transform: function (response) {

                //Sorts the suggestions by name 
               var sortedResponse = response.sort(function (a, b) {
                    var nameA = a.Name.toUpperCase(); // ignore upper and lowercase
                    var nameB = b.Name.toUpperCase(); // ignore upper and lowercase
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }

                    // names must be equal
                    return 0;
               });

                var availableBooks = sortedResponse.forEach(function (book) {
                });

                return sortedResponse;
            }
        }
        
    });


    //If coming from Book view, GET all the books from the database and search for the ids and display the books, else just draw first input
    if (!(bookIds.length === 0)) {
        $.get("/api/books", function (data) {

            bookIds.forEach(function (bookId) {

                
                var book = data.find(o => o.Id === bookId);

                var bookElement =
                {
                    Name: book.Name,
                    Id: book.Id
                };

                bookList.push(bookElement);

            });

            drawInputs();

        });

    } else {
        drawInputs();
    }





    //Submit form event, calls the POST api and clears the form data:
    $('#reservationForm').submit(function (event) {

        event.preventDefault();

        var MemberId = $('#MemberId').val();

        var data = { 'Books': bookList, 'MemberId': MemberId };


        $.ajax({
            url: "/api/reservations",
            method: "POST",
            data: data,
            dataType: "json",
            success: function (data) {

                //Display success message for each successful reservation
                data[0].forEach(function (book) {
                    toastr.success("Knjiga " + book.Name + " je uspješno dodana na listu rezervacija!");

                });

                //Display error message for each failed reservation
                data[1].forEach(function (book) {
                    toastr.error("Knjiga " + book.Name + " nije dodana. Dosegnut je maksimalan broj rezervacija.")
                });

                //Clear the list on success
                bookList.splice(0, bookList.length);

                //After the list is clear, draw the inputs again
                drawInputs();

                //Clear member id 
                $('#MemberId').val('');
            }
        });

    });


    //Initializes typeahead for each input that exists
    function typeaheadInit() {


        $('.typeaheadInput').typeahead({
            minLength: 1,
            highlight: true
        }, {
            name: 'books',
            limit: 20,
            display: 'Name',
            source: book,
            templates: {
                //This fires for every suggestion that shows up, if it's not available make it unclickable in the suggestion box
                suggestion: function (data) {
                    if (data.NumberAvailable <= 0)
                       return "<div class='notAvailable'>" + data.Name + "<span class='notAvailableSpan'>\t\t trenutno nedostupna</span></div>";
                    return "<div class=''>" + data.Name + "</div>";
                }

                }
        }).on("typeahead:select", function (e, book) {

            //get index of selected element
            //typeahead auto wraps each input in span and adds a second input (see chrome F12 elements),
            //so this input is in a span with another input (which comes first) and index would always return 1,
            //so we call the first parent() to get out of the div and call the second parent() to get to the span
            //which gives us the correct index
            var index = $(this).parent().parent().index();

            var listElement = {
                Name: book.Name,
                Id: book.Id
            };

            //checks if element at this index exists in the list, if it doesn't it means its a new input,
            // and if it does it means it's an edit of an existing input
            if (bookList[index] === undefined) {

                bookList.push(listElement);
            } else {
                bookList.splice(index, 1, listElement);
            }


            drawInputs();

        });



    };


    //handles the input removal when user clicks on X
    $('#reservationForm').on('click',".removeInput", function (e) {
        e.preventDefault();

        //get index of span element in which is all this and remove that index from list
        var index = $(this).parent().index();
        bookList.splice(index, 1);

        //then redraw inputs again
        drawInputs();

    });
    


    //Populates the empty input with the value from the list at given index 
    function populateInput(index) {

        var listOfInputs = $('#dynamicInputDiv').find('input');


        //populate the input at the given index with the value from the list at given index


        if (!(bookList[index] === undefined)) 
            $(listOfInputs[index]).val(bookList[index].Name);

    }


    //handles the drawing of inputs, this gets called every time there's a new input or editing of a existing one
    function drawInputs() {

        //Get the empty input div from another file for easier manipulation, everything else is in callback function because of async
        $.get("../../Dynamic Html/EmptyInput.html", function (input) {

            //First, remove all inputs
            $('#dynamicInputDiv').empty();



            //Create empty inputs and populate them corresponding to how many elements are in the list (+ 1 to create the next empty input)
            for (var i = 0; i < bookList.length + 1; i++) {

                //check for MAX_INPUT, if it's the last input don't add new empty input
                if (i === MAXINPUT && bookList.length === MAXINPUT) {
                    populateInput(i);
                    break;
                }

                $('#dynamicInputDiv').append(input);

                populateInput(i);
            }

            //bond typeahead to inputs
            typeaheadInit();
        });
    }





});
