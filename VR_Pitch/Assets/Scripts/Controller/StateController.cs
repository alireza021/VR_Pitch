using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    /**
     * The StateController holds and manages transitions between the modes/views.
     */
    public class StateController : MonoBehaviour
    {
        public LobbyScene lobbyScene;
        public HandshakeScene handshakeScene;
        public OneononeScene oneononeScene;
        public TeamScene teamScene;
        public EndScene endScene;


        public Dictionary<ViewMode, IPage> modeToPage;
        /**
        * Set Mode to initiate transition between two modes.
        */
        public ViewMode mode
        {
            get => _mode;
            set
            {
                if (value == _mode) return;
                modeToPage[_mode].Deactivate();
                _mode = value;
                if (modeToPage.ContainsKey(_mode) && modeToPage[_mode] != null)
                {
                    modeToPage[_mode].Activate();
                }
            }
        }

        private ViewMode _mode;


        void Awake()
        {
            modeToPage = new Dictionary<ViewMode, IPage>
            {
                {ViewMode.LOBBY, lobbyScene},
                {ViewMode.HANDSHAKE, handshakeScene },
                {ViewMode.ONEONONE, oneononeScene },
                {ViewMode.TEAM, teamScene },
                {ViewMode.END, endScene }
            };
        }

        void Start()
        {
            try
            {
                endScene.Deactivate();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error deactivating endScene: {e}");
            }

            try
            {
                teamScene.Deactivate();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error deactivating teamScene: {e}");
            }

            try
            {
                oneononeScene.Deactivate();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error deactivating oneononeScene: {e}");
            }
            try
            {
                handshakeScene.Deactivate();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error deactivating handshakeScene: {e}");
            }

            try
            {
                lobbyScene.Activate();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Error activating lobbyScene: {e}");
            }


        }


    }
}