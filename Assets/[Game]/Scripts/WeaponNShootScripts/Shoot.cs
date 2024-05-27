using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem muzzleFlash; // Particle system for smoke effect
    [SerializeField] private float _bulletSpeed = 10;
    [SerializeField] private float _fireRate = 0.5f; // Fire rate for automatic firing
    [SerializeField] private float _recoilAmount = 0.1f;
    [SerializeField] private float _recoilSpeed = 5f; // Speed of recoil recovery

    private Vector3 _originalPosition;
    private bool _isShooting;
    private Weapon _weaponScript;
    private float _nextFireTime;
    private Coroutine _shootCoroutine;

    private void Start()
    {
        _originalPosition = transform.localPosition; // Save the original position for recoil recovery
        _weaponScript = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            if (_shootCoroutine == null)
            {
                _nextFireTime = Time.time + _fireRate;
                _shootCoroutine = StartCoroutine(ShootRoutine());
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
                _shootCoroutine = null;
                _isShooting = false;
            }
        }

        // Smoothly recover from recoil
        transform.localPosition = Vector3.Lerp(transform.localPosition, _originalPosition, Time.deltaTime * _recoilSpeed);
    }

    private IEnumerator ShootRoutine()
    {
        _isShooting = true;
        while (_isShooting)
        {
            Fire();
            _nextFireTime = Time.time + _fireRate;
            yield return new WaitForSeconds(_fireRate);
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * _bulletSpeed;

        // Play muzzle flash particle effect
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // Apply recoil only if not aiming
        if (!_weaponScript.isAiming)
        {
            transform.localPosition -= new Vector3(0, 0, _recoilAmount);
        }
    }
}
