document.querySelector("#frmLogin").addEventListener('submit', function (e) {
  e.preventDefault();
  ajaxPost(this, alert, data => {
    if (data.ok) {
      alert('Logged in');
      window.location.reload();
    } else {
      alert(d.message)
    }
  })
})

document.querySelector("#frmSignup").addEventListener('submit', function (e) {
  e.preventDefault();
  ajaxPost(this, alert, data => {
    if (data.ok) {
      alert('Signed up');
      window.location.reload();
    } else {
      alert(d.message)
    }
  })
})