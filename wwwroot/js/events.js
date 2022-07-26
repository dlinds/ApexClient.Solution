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
          $('#result').html(response);
        },
      error:
        (response) => {
          $('#result').html("<p>No applications were found!</p>");
        }
    }
  );
});
