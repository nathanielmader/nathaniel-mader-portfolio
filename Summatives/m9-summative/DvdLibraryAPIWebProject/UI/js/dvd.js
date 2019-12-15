$(document).ready(function () {
      hideCreateForm();
      hideEditForm();
      loadDvds();


      $('#mainCreateDvdButton').click(function(event) {
            $('#mainPage').hide();
            $('#createPage').show();
      })

      $('#createDvdButton').click(function (event){
        $('#createPageErrorMessages').empty();
        //clearCreateTable();
        //$('createPageErrorMessages').empty();

        if($('#dvdTitle').val() == ''){
          $('#createPageErrorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Please enter a title for the DVD'));

              var stop = true;
        }

        if($('#dvdReleaseYear').val().length < 4){
          $('#createPageErrorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Please enter a 4-digit year'));

              var stop = true;
        }

        if(stop==true)
        {
          return false;
        }

          $.ajax({
              type: 'POST',
              url: 'http://localhost:53857/dvd',
              data: JSON.stringify({
                  title: $('#dvdTitle').val(),
                  realeaseYear: $('#dvdReleaseYear').val(),
                  director: $('#dvdDirector').val(),
                  rating: $('#dvdRating').val(),
                  notes: $('#dvdNotes').val()
              }),
              headers: {
                'Accept': 'application/json',
                'Content-Type':'application/json'
              },
              'dataType':'json',
              success: function(){
                //clearAllErrorMessages();//clear error messages on page
                //Its not a form, its a click handler, all dasta stays in form, so need to clear manually
                $('#dvdTitle').val('');
                $('#dvdReleaseYear').val('');
                $('#dvdDirector').val('');
                $('#dvdRating').val('');
                $('#dvdNotes').val('');
                loadDvds();//Puts new contact into table and displays
                $('#createPageErrorMessages').empty();
              },
              error: function(){
                $('#createPageErrorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Error'));
              }
              })
            });

            $('#editSaveChangesButton').click(function(event){
              $('#editPageErrorMessages').empty();
              //clearCreateTable();
              //$('createPageErrorMessages').empty();

              if($('#edtDvdTitle').val() == ''){
                $('#editPageErrorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Please enter a title for the DVD'));

                    var stop = true;
              }

              if($('#editDvdReleaseYear').val().length < 4){
                $('#editPageErrorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Please enter a 4-digit year'));

                    var stop = true;
              }

              if(stop==true)
              {
                return false;
              }
                  $.ajax({
                    type: 'PUT',
                    url: 'http://localhost:53857/dvd/' + $('#editDvdId').val(),
                    data: JSON.stringify({
                      dvdId: $('#editDvdId').val(),
                      title: $('#editDvdTitle').val(),
                      realeaseYear: $('#editDvdReleaseYear').val(),
                      director: $('#editDvdDirector').val(),
                      rating: $('#editDvdRating').val(),
                      notes: $('#editDvdNotes').val()
                    }),
                    headers: {
                      'Accept': 'application/json',
                      'Content-Type':'application/json'
                    },
                    'dataType':'json',
                    success: function(){
                          //$('#editPageErrorMessages').empty();
                          loadDvds();
                    },
                    error: function(){
                      $('#editPageErrorMessages')
                          .append($('<li>')
                          .attr({class: 'list-group-item list-group-item-danger'})
                          .text('Error'));
                    }
                  })
            })
    });

function loadDvds(){
  clearDvdTable();
  reset();
  var contentRows = $('#contentRows');
  $.ajax({
    type: 'GET',
    url: 'http://localhost:53857/dvds',
    success: function(dvdArray){

        $.each(dvdArray, function(index, dvd) {
            var id = dvd.dvdId;
            var title = dvd.title;
            var releaseDate = dvd.realeaseYear;
            var director = dvd.director;
            var rating = dvd.rating;


            var row = '<tr>';
                row += '<td><a onclick="displayDvdPage(' + id + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a onclick="showEditForm(' + id + ')">Edit</a></td>';
                row += '<td><a onclick="deleteDvd(' + id + ')">Delete</a></td>';
                row += '</tr>';

            contentRows.append(row);
        });
    },
    error: function() {

          }
  });
}



function clearDvdTable(){
  $('#contentRows').empty();
}

function showEditForm(dvdId){

    $.ajax({
        type: 'GET',
        url: 'http://localhost:53857/dvd/' + dvdId,
        success: function(data, status){
          $('#editDvdId').val(data.dvdId);
          $('#editDvdTitle').val(data.title);
          $('#editDvdReleaseYear').val(data.realeaseYear);
          $('#editDvdDirector').val(data.director);
          $('#editDvdRating').val(data.rating);
          $('#editDvdNotes').val(data.notes);
        },
        error: function() {


          }
    });
    $('#mainPage').hide();
    $('#createPage').hide();
    $('#editPage').show();

}

function hideEditForm(){
    //$('#editPageErrorMessages').empty();
    //Want to clear form upon cancellation
    $('#editDvdTitle').val('');
    $('#editDvdReleaseYear').val('');
    $('#editDvdDirector').val('');
    $('#editDvdRating').val('');
    $('#editDvdNotes').val('');
    clearAllErrorMessages();
    $('#createPage').hide();
    //$('#displayPage').hide();
    $('#editPage').hide();
    $('#mainPage').show();
}

function hideCreateForm(){
    //$('#createPageErrorMessages').empty();
    //Want to clear form upon cancellation
    $('#dvdTitle').val('');
    $('#dvdReleaseYear').val('');
    $('#dvdDirector').val('');
    $('#dvdRating').val('');
    $('#dvdNotes').val('');
    clearAllErrorMessages();
    $('#createPage').hide();
    //$('#displayPage').hide();
    $('#editPage').hide();
    $('#mainPage').show();
}

function clearAllErrorMessages(){
      $('#createPageErrorMessages').empty();
      $('#editPageErrorMessages').empty();
      $('#mainPageErrorMessages').empty();
}

function reset(){
    $('#mainPage').show();
    $('#editPage').hide();
    $('#createPage').hide();
    $('#displayPage').hide();
}

function hideDisplayForm(){
    $('#displayDvdTitle').val('');
    $('#displayDvdReleaseYear').val('');
    $('#displayDvdDirector').val('');
    $('#displayDvdRating').val('');
    $('#displayDvdNotes').val('');

    loadDvds();
}

function displayDvdPage(dvdId){
    $('#editPage').hide();
    $('#createPage').hide();
    $('#mainPage').hide();
    $('#displayPage').show();
  $.ajax({
        type: 'GET',
        url: 'http://localhost:53857/dvd/' + dvdId,
        success: function(data, status){
              $('#displayDvdTitle').text(data.title);
              $('#displayDvdReleaseYear').text(data.realeaseYear);
              $('#displayDvdDirector').text(data.director);
              $('#displayDvdRating').text(data.rating);
              $('#displayDvdNotes').text(data.notes);
        },
        error: function(){
          $('#mainPageErrorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Error'));
        }
  })
}
function deleteConfirm(DvdId){
  if(confirm("Are you sure yoy want to delete this DVD?") == true)
  {
    deleteDvd(dvdId)
  }
  else{
    loadDvds();
  }
}
function deleteDvd(dvdId){
            $.ajax({
                type: 'DELETE',
                url: 'http://localhost:53857/dvd/' + dvdId,
                success: function(){
                    loadDvds();
                }
            });
}
function clearCreateTable(){
  $('#dvdTitle').val('');
  $('#dvdReleaseYear').val('');
  $('#dvdDirector').val('');
  $('#dvdRating').val('');
  $('#dvdNotes').val('');
}
