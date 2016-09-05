public var ground : Transform;  //地面オブジェクト
public var interval : float = 5;//何秒おきに敵を発生させるか
public var count : float = 5;   //一度にスポーンさせる敵の数
public var enemy : GameObject;  //敵オブジェクト
public var enemy2 : GameObject;  //敵オブジェクト
public var enemy3 : GameObject;  //敵オブジェクト
private var timer : float;      //タイマー処理に使う経過時間
 
function Start () {
    Spawn();    //初期スポーン
}
 
function Update () {
    timer += Time.deltaTime;
    if(timer >= interval){
        Spawn();
        timer = 0;
    }
}
 
function Spawn () {
    for(var i =0; i < count ; i++) {
    //ランダム生成する際の範囲が-25~25なのは地面の大きさが50だから
        var x : float = Random.Range(-25f, 25f);    //x座標をランダム生成
        var z : float = Random.Range(-25f, 25f);    //z座標をランダム生成
        var pos : Vector3 = Vector3(x, 5, z );//ランダム生成の位置座標を作成
        pos += ground.position;
        var rd : float = Random.Range(0, 10);
        if(rd == 1){
		GameObject.Instantiate(enemy, pos, Quaternion.identity) ;
	    }else if(rd == 0){
	    GameObject.Instantiate(enemy3, pos, Quaternion.identity) ;
	    }else{
	    GameObject.Instantiate(enemy2, pos, Quaternion.identity) ;
	    }
        //第一引数は生成するオブジェクト
        //第二引数は生成する座標
        //第三引数は生成したオブジェクトの向き
    }
}
