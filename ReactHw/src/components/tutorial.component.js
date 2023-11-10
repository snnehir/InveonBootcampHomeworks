import React, {Component} from "react";
import tutorialService from "../services/tutorial.service";
export default class Tutorial extends Component {

    constructor(props)
    {
        super(props);
        this.state = {
            guncellenecekTutorial : {
                id : null,
                title : '',
                description : '',
                published : false
            }
        }
    }


    componentDidMount() {
        console.log("bir önceki sayfadana gelen id : "+ this.props.match.params.id);
        //this.detayTutorial(this.props.match.params.id);
    }

    detayTutorial(id) {
    tutorialService.get(id).then(gelenDetayTutorial => {
        console.log(gelenDetayTutorial);
        this.setState({
            guncellenecekTutorial : gelenDetayTutorial.data
        });
       
    }).catch(hata => {
        console.log("detaya gelmedi : " +hata );
    })
    }

    render() {
        return(
            <div>Tutorial detay sayfasıdır</div>
        )
    }

}