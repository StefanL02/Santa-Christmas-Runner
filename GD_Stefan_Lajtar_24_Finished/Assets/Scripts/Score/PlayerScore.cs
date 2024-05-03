using Assets.Scripts.Observer;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Score
{
    public class PlayerScore : MonoBehaviour, IObserver
    {
        [SerializeField] Subject<IObserver> _playerSubject;
        private int _score = 0;
        private Text _playerText;

        private void Start()
        {
            
            var component = transform.Find("CoinCount");
            _playerText = component.GetComponent<Text>();
            if(_playerText == null)
            {
                Debug.Log("Failed to get playertext");
            }
        }
        public void OnNotify()
        {
            _playerText.text = $"{++_score}";
            Debug.Log($"Current text is: {_playerText.text}");
        }

        private void OnEnable()
        {
            _playerSubject.AddObserver(this);
        }

        private void OnDisable()
        {
            _playerSubject.RemoveObserver(this);
        }
    }
}
