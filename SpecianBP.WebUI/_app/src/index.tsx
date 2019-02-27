import * as React from 'react';
import * as ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

import { App } from './App';

ReactDOM.render(
  <App />,
  document.getElementById('root')
);

      /*
      
      */

      /*
          -paging
      
          --------------bootstrap npm install
          --------------layout
          --------------3stranky
          --------------url
          --------------breadcrumb
          --------------projects ul
          --------------langs select
          --------------odstranit root
          --------------modal okno pro new res key
          --------------filter by original, filter by resource
      
      
          --------------tlacitko new - ovladaci visible div s formularem pro nove res key
          --------------inputy v tabulce nejsou bootstrap
          --------------udelat list z projektu a jazyku
      
          ---------------project komponenta
          -------------- lang konponenta
          ---------------rozdelit model na lang model a project model
          ---------------componentDidMount
          ---------------loading resi komponenta projekt, ne app, - bude videt zahlavi vzdy 
          ---------------
      
            -------------export import
          -refactor, komentovat
          -
      
          --------------in progress indikator pro resource keys editor
          --------------filtering pro resource keys  editor
          --------------editorovaci tabulky by mely vypadat jako v excelu - ted maji vysoke okraje
      
          --------------input v tabulce musi reagovat na onchange a menit stav modelu
          --------------on blur bude volat update do db, ne menit stav modelu
      
          --------------rozdeleni dat na state a data ze serveru - nemichat, odebrat state z interfacu
          --------------mit kolekci mensich modelů na ResourceKeys modelu - ResourceKeyModel - drzi si data o jednom resourceKey a jeho state
          --------------pozdeji rozdelit tabulku - kazdy radek vlastni komponenta - rerender se vola pouze na ni - neposilat state na server
      
          --------------navigace pomoci sipek po tabulce - sipka nahoru posun mezi komponentami
      
          ------------ page size inptu v pravo, vpravo ukazat kolik z kolika polozek vidim
          ------------ zmensit jeste vic
          --------------- do td vlozit div classname = tdcontent a pomoci nej css
          ------------ more nechat zit
          ------------ filtering - computed za pomoci sortingu filterinputu
          ------------ sorting na obě strany
          ------ zmensit i header tabulky
          ------ filtrovaci formular doleva
          ------ filtering - nikdy neneahravat znovu - spatne
          ------ filtering pomoci contains - kombinace shody ze zacatku slova a kombinace contains
          ------ na serveru nic nedelat
          -------- sloucit filterboxy do jednoho
          - udelat index hledani - nejdriv zobrazim shody od zacatku slova, pak zobrazim contains
              -udelat vlastni metodu includes vracejici cislo na pro komparator a filtr
          --------- pro paging componentu dropdown
          --------- empty desc pryc
          -// pri hledani nedavat sorting
          --------s modelem hejbat jenom na onblur, nelze jinak, nefunguji empty_only radky
      
      
          -integrace startupu
          -------------importy a exporty resx
      */

      /*
        --------------Display name a user Name - not first and last name
        --------------Refactor of TestData static class
        --------------user name editable only when creating new user - afterways disabled input

        Removable - project, user, resource key - trash icon - test
        grant in user remove, grant in rk remove, grant in project remove
        grants add to testdata roles and to current user dto as booleans

      */