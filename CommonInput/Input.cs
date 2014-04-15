﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MifuminSoft.funya3.Input
{
    class KeyState
    {
        public bool Pressed { get; private set; }
        public bool Pushed { get; private set; }
        public bool Released { get; private set; }

        public void SetState(bool pressed)
        {
            Pushed = !Pressed && pressed;
            Released = Pressed && !pressed;
            Pressed = pressed;
        }
    }

    enum Key
    {
        Exit,
        Pause,
        Up,
        Left,
        Right,
        Down,
        Jump,
        Attack,
        Smile,
        Fps,
        BgmNone,
        BgmDefault,
        BgmUser,
        Capture,
        Record,
    }

    abstract class Input
    {
        private Dictionary<Key, KeyState> KeyState;

        public Input()
        {
            KeyState = new Dictionary<Key, KeyState>();
            foreach (var key in typeof(Key).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (key.IsLiteral) KeyState[(Key)key.GetValue(null)] = new KeyState();
            }
        }

        /// <summary>キーが今押されているかどうかを返す。</summary>
        /// <param name="key">キー</param>
        /// <returns>キーが今押されているかどうか</returns>
        public bool IsKeyPressed(Key key) { return KeyState[key].Pressed; }

        /// <summary>キーがたった今押されたかどうかを返す。</summary>
        /// <param name="key">キー</param>
        /// <returns>キーがたった今押されたかどうか</returns>
        public bool IsKeyPushed(Key key) { return KeyState[key].Pushed; }

        /// <summary>キーがたった今離されたかどうかを返す。</summary>
        /// <param name="key">キー</param>
        /// <returns>キーがたった今離されたかどうか</returns>
        public bool IsKeyReleased(Key key) { return KeyState[key].Released; }

        /// <summary>入力状態を更新します</summary>
        public void Update()
        {
            foreach (var key in KeyState.Keys) UpdateKey(key);
        }

        /// <summary>派生クラスでキーの状態を更新するコードを実装してください。</summary>
        /// <param name="key">キー</param>
        protected abstract void UpdateKey(Key key);

        /// <summary>キーの状態を設定します。UpdateKeyから呼び出してください。</summary>
        /// <param name="key">キー</param>
        /// <param name="pressed">キーが今押されているかどうか</param>
        protected void SetKeyStatus(Key key, bool pressed)
        {
            KeyState[key].SetState(pressed);
        }
    }
}
