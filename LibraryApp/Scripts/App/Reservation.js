$(document).ready(function () {

    var list = [];
    var MAXINPUT = 4;

    var book = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/books?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    createEmptyInput();
    removeInput();
    typeaheadInit();


    //Submit form event, calls the POST api and clears the form data:
    $('#reservationForm').submit(function (event) {

        event.preventDefault();

        var MemberId = $('#MemberId').val();

        var data = { 'BookIds': list, 'MemberId': MemberId };


        $.ajax({
            url: "/api/reservations",
            method: "POST",
            data: data,
            success: function () {

                //Clear the form on success
                $('#MemberId').val('');
                $('#BookId').val('');
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
            source: book
        }).on("typeahead:select", function (e, book) {

            //get index of selected element
            //typeahead auto wraps each input in span and adds a second input (see chrome F12 elements),
            //so this input is in a span with another input (which comes first) and index would always return 1,
            //so we call the first parent() to get out of the div and call the second parent() to get to the span
            //which gives us the correct index
            var index = $(this).parent().parent().index();



            //checks if element at this index exists in the list, if it doesn't it means its a new input,
            // and if it does it means it's an edit of an existing input
            if (list[index] === undefined) {
                list.push(book.Name);
            } else {
                list.splice(index, 1, book.Name);
            }


            redrawInputs();

        });

    };


    //handles the input removal when user clicks on X
    function removeInput() {
        $('.removeInput').on('click', function (e) {
            e.preventDefault();

            //get index of span element in which is all this and remove that index from list
            var index = $(this).parent().index();
            list.splice(index, 1);

            //then redraw inputs again
            redrawInputs();

        });
    }


    //Appends an empty input to the div
    function createEmptyInput() {
        var input = "<div class='typeaheadDiv'>" +
            "<input type='text' class='typeaheadInput' placeholder='Dodaj knjigu'/>" +
            "<a href='' class='removeInput'>X</a> " +
            "</div>";

        $('#dynamicInputDiv').append(input);

    }


    //Populates the empty input with the value from the list at given index 
    function populateInput(index) {

        var listOfInputs = $('#dynamicInputDiv').find('input');


        //populate the input at the given index with the value from the list at given index
        $(listOfInputs[index]).val(list[index]);

    }


    //handles the redrawing of inputs, this gets called every time there's a new input or editing of a existing one
    function redrawInputs() {


        //First, remove all inputs
        $('#dynamicInputDiv').empty();



        //Create empty inputs and populate them corresponding to how many elements are in the list (+ 1 to create the next empty input)
        for (var i = 0; i < list.length + 1; i++) {

            //check for MAX_INPUT, if it's the last input don't add new empty input
            if (i === MAXINPUT && list.length === MAXINPUT) {
                populateInput(i);
                break;
            }

            createEmptyInput();

            populateInput(i);
        }

        //bond typeahead to inputs
        typeaheadInit();

        //bond removeInput to inputs
        removeInput();


    }

});
