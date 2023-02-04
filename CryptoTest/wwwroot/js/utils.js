function ajaxPost(form, errorHandler, successHandler) {  
  const data = new URLSearchParams();
  for (const pair of new FormData(form)) {
    data.append(pair[0], pair[1]);
  }

  fetch(form.getAttribute("action"), {
    method: 'post',
    body: data,
  }).then(res => {
    if (res.ok) {
      return res.json()
    } else {
      throw Error("Couldn't communicate")
    }
  }).then(data => successHandler(data))
    .catch(e => errorHandler(e));
}