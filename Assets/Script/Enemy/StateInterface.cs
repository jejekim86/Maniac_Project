using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    // ���°� ���۵ɶ� ȣ���
    public void EnterState();

    // �� ������ ���� ȣ���
    public void UpdateState();

    // ���°� ����ɶ� ȣ���
    public void ExitState();
}