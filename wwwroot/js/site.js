// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#applicationSearchForm").submit(event => {
  event.preventDefault();
  const name = (event.target.name.value !== "-- Select --")
    ? event.target.name.value : null;
  const manufacturer = (event.target.manufacturer.value !== "-- Select --")
    ? event.target.manufacturer.value : null;
  const version = (event.target.version.value !== "-- Select --")
    ? event.target.version.value : null;
  $.ajax(
    {
      url: '/Applications/LoadApplicationSearchResults',
      contentType: 'application/html; charset=utf-8',
      type: 'GET',
      dataType: 'html',
      data: { name: name, version: version, manufacturer: manufacturer },
      success:
        (response) => {
          // Generate HTML table.
          $('#applicationResult').html(response);
        },
      error:
        (response) => {
          $('#applicationResult').html("<p>No applications were found!</p>");
        }
    }
  );
});

function newCommandForm(event) {
  console.log(event);
  const applicationId = event.target.applicationId.value;
  const keyword = event.target.keyword.value;
  const shortcut = event.target.shortcut.value;
  const commandId = (event.target.commandId.value != null) ? event.target.commandId.value : null;
  console.log("here: ", applicationId, keyword, shortcut)
  $.ajax(
    {
      url: '/Commands/CreateNewCommand',
      type: 'POST',
      data: { applicationId: applicationId, keyword: keyword, shortcut: shortcut, commandId: commandId },
      success:
        () => {
          loadCommandByApplicationId(applicationId);
        },
      error:
        (response) => {
          $('#applicationResult').html(`<p>There was an issue posting the new command: ${response.responseText}</p>`);
        }
    }
  );
}

function loadCommandByApplicationId(id) {
  $.ajax(
    {
      url: '/Commands/LoadCommandsByAppId',
      contentType: 'application/html; charset=utf-8',
      type: 'GET',
      dataType: 'html',
      data: { applicationId: id },
      success:
        (response) => {
          // Generate HTML table.
          $('#applicationResult').html(response);
        },
      error:
        (response) => {
          console.log(response)
          $('#applicationResult').html("<p>No applications were found this time!</p>");
        }
    }
  );
}

function loadNewCommandForm(applicationId, commandId) {
  const idOfCommand = (commandId == null) ? null : commandId
  $.ajax(
    {
      url: '/Commands/LoadNewEditCommandForm',
      contentType: 'application/html; charset=utf-8',
      type: 'GET',
      dataType: 'html',
      data: { applicationId: applicationId, commandId: idOfCommand },
      success:
        (response) => {
          // Generate HTML table.
          $('#applicationResult').html(response);
        },
      error:
        (response) => {
          console.log(response)
          $('#applicationResult').html("<p>No applications were found this time!</p>");
        }
    }
  );
}

const resetSelect = e => {
  $(`#${e}`).prop('selectedIndex', 0);
}
