import React, { Component } from "react";
import tutorialService from "../services/tutorial.service";
import { Link } from "react-router-dom";
export default class TutorialsList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            tutorials: [],
            currentIndex: -1,
            currentTutorial: null,
            filteredTutorials: [],
            searchTerm: ""
        }

    }

    //tutoriallist sayfası çağrıldığında devreye giren fonksiyon
    componentDidMount() {
        this.tutorialllariGetir();
    }

    tutorialllariGetir() {
        // Network error
        // tutorialService.getAll().then(tutorialListesi => {
        //     this.setState({
        //         tutorials: tutorialListesi,
        //         filteredTutorials: tutorialListesi
        //     });
        // }).catch(hata => {

        //     console.log("hata oluştu" + hata);
        // })
        // example data
        let data = [{ title: "todo 1 lorem", description: "description 1" },
        { title: "todo 2 ipsum", description: "description 2" },
        { title: "todo 3 dolor", description: "description 3" },
        { title: "todo 4 sit", description: "description 4" },
        { title: "todo 5 amet", description: "description 5" }
        ]
        this.setState({
            tutorials: data,
            filteredTutorials: data
        });
    }

    filterBySearchTerm(input, tutorials) {
        this.setState({
            filteredTutorials: tutorials !== undefined ? tutorials.filter(t => t.title.toLowerCase().includes(input.toLowerCase())) : [],
        })
    }

    setSearchTerm(input) {
        this.setState({
            searchTerm: input
        })
    }

    AktifTutorial(tutorial, index) {
        this.setState({
            currentTutorial: tutorial,
            currentIndex: index
        })
    }


    render() {
        const { tutorials, currentTutorial, currentIndex, filteredTutorials, searchTerm } = this.state
        return (
            <div className="list row">

                <div className="col-md-6">
                    <h4>Tutorial Listesi</h4>
                    {/* search area */}
                    <div className="d-flex my-2">
                        <input placeholder="Başlıkla ara..." type="text" onChange={(e) => this.setSearchTerm(e.target.value)}></input>
                        <button className="btn btn-primary" onClick={() => { this.filterBySearchTerm(searchTerm, tutorials) }}>Ara</button>
                    </div>
                    <ul className="list-group">
                        {filteredTutorials &&
                            <>

                                {filteredTutorials.length > 0 ?

                                    filteredTutorials.map((tutorial, index) => ( //tutorials array içindeki her bir elemanı tutorial nesnesi olarak kullandık
                                        <li className={"list-group-item " + (index === currentIndex ? "active" : "")}
                                            onClick={() => this.AktifTutorial(tutorial, index)}
                                            key={index}>
                                            {tutorial.title}
                                        </li>
                                    ))
                                    :
                                    <div>Todo bulunamadı.</div>
                                }
                            </>
                        }


                    </ul>
                </div>

                <div className="col-md-6">
                    {currentTutorial ?
                        (
                            <div>
                                <h4>Tutorial</h4>
                                <div>
                                    <label>
                                        <strong>Başlık : </strong>
                                    </label>{" "}{currentTutorial.title}
                                </div>
                                <div>
                                    <label>
                                        <strong>Açıklama : </strong>
                                    </label>{" "}{currentTutorial.description}
                                </div>
                                <div>
                                    <label>
                                        <strong>Durum : </strong>
                                    </label>{" "}{currentTutorial.published ? "Yayınlandı " : "Bekleniyor..."}
                                </div>
                                <Link to={"/tutorials/" + currentTutorial.id} className="btn btn-success">Düzenle</Link>
                            </div>
                        ) :
                        (
                            <div></div>
                        )}
                </div>
            </div>
        )

    }

}