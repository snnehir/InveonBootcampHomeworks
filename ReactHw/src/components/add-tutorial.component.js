import React, {Component} from "react";
import tutorialService from "../services/tutorial.service";
export default class AddTutorial extends Component {


    constructor(props)
    {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription= this.onChangeDescription.bind(this);
        this.state = {
            id : null,
            title : '',
            description : '',
            published : false,
            kaydedildi : false
        }
      
    }

    tutorialKaydet() {
         console.log("kaydet tıklandı");
        var kaydedilecekTutorial ={
          title : this.state.title,
          description : this.state.description,
          published : false
        };
        tutorialService.create(kaydedilecekTutorial)
        .then(yeniEklenenTutorial => {
           console.log(yeniEklenenTutorial);
           window.location.href="/tutorials";
        }).catch(hata => {
            console.log("hata oluştu : " +hata);
        })
    }

    onChangeTitle(e)
    {
        console.log(e.target.value);
        this.setState({
            title :  e.target.value
        
        })
    }

    onChangeDescription(e)
    {
        console.log(e.target.value);
        this.setState({
            description :  e.target.value
        
        })
    }
    render() {
        
        return(
            <div className="submit-form">
                 <div className="form-group">
                    <label htmlFor="title" >Title : </label>
                    <input type="text"
                    className="form-control"
                    id="title"
                    required
                    onChange={this.onChangeTitle}
                    value={this.state.title} ></input>
                 </div>
                 <br />
                 <div className="form-group">
                    <label htmlFor="description" >Description : </label>
                    <input type="text"
                    className="form-control"
                    id="description"
                    onChange={this.onChangeDescription}
                    value={this.state.description} ></input>
                 </div>
                 <br />
                 <button className="btn btn-success" onClick={() =>this.tutorialKaydet()} >Kaydet</button>
            </div>
        )
    }

}