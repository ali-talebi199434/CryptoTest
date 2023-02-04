document.addEventListener('DOMContentLoaded', function () {
  let socket = io(":3001");

  const tbody = document.querySelector("#tbody");
  const raised = 'raised';
  const dropped = 'dropped';
  socket.on('trade', (trade) => {    
    const tr = tbody.querySelector(`tr[data-base="${trade.base}"][data-quote="${trade.quote}"]`);
    if (tr) {
      const td = tr.querySelector(`td.${trade.side}`);
      td.firstElementChild.textContent = trade.price;
      let lastPrice = td.dataset.lastprice;      
      if (lastPrice) {        
        lastPrice = Number(lastPrice);
        td.classList.remove(raised, dropped);
        if (trade.price > lastPrice) td.classList.add(raised);
        else if (trade.price < lastPrice) td.classList.add(dropped);        
      }
      td.setAttribute('data-lastprice', trade.price);
    }
  })
})
